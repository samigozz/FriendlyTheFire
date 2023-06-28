using System;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Tree : MonoBehaviour, IInteractable
{
    [Header("General")] [SerializeField] private Transform cutPos;

    [SerializeField] private IntValue woodValue;
    [SerializeField] private GameEvent onPickWood;

    private bool isGrown = true;
    private int health = 3;
    private int gainedWood = 0;
    
    [Header("Sprites")] [SerializeField] private SpriteRenderer treeSR;
    [SerializeField] private SpriteRenderer stumpSR;
    [SerializeField] private Sprite fullTree;
    [SerializeField] private Sprite cutTree;

    [Header("Animation")] 
    [SerializeField] Vector3 shakeStrength;
    [SerializeField] float fallDuration = 1f;
    Sequence sequence;

    [Header("Mini-games")] [SerializeField]
    private Transform target;

    [SerializeField] private Transform pivot;

    [SerializeField] private GameObject rotatingMiniGame;

    [SerializeField, Range(0f, 1f)] private float reactThreshold = 0.95f;
    [SerializeField, Range(0f, 1f)] private float[] tieredThresholds = new float[3] { 0.95f, 0.99f, 0.995f };
    [SerializeField] private int[] woodPerTier = new int[3] { 1, 3, 5 };


    private void Start()
    {
        stumpSR.gameObject.SetActive(false);
        //Hide the minigame
        rotatingMiniGame.SetActive(false);
    }

    // Triggers for showing and hiding the minigame, not very efficient but works.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isGrown && other.gameObject.tag == "Player")
        {
            rotatingMiniGame.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (isGrown && other.gameObject.tag == "Player")
        {
            rotatingMiniGame.SetActive(false);
        }
    }

    public void Interact()
    {
        if (!isGrown)
            return;

        float result = Mathf.Clamp(Vector3.Dot(target.transform.up, pivot.transform.up), 0f, 1f);

        if (result >= tieredThresholds[0] || result <= -tieredThresholds[0])
        {
            // Cutting tree animation and health.
            Shake();
            health--;

            //Debug.Log($"<color=blue>{result}</color>");

            if ((result >= tieredThresholds[0] && result <= tieredThresholds[1]) || (result < -tieredThresholds[0] && result >= -tieredThresholds[1]))
            {
                Debug.Log("Nice!");
                gainedWood += woodPerTier[0];
            }
            else if ((result >= tieredThresholds[1] && result <= tieredThresholds[2]) || (result < -tieredThresholds[1] && result >= -tieredThresholds[2]))
            {
                Debug.Log("Fantastic!");
                gainedWood += woodPerTier[1];
            }
            else if (result > tieredThresholds[2] || result < -tieredThresholds[2])
            {
                Debug.Log("Perfect!");
                gainedWood += woodPerTier[2];
            }

            if (health <= 0)
            {
                isGrown = false;
                rotatingMiniGame.SetActive(false);
                treeSR.sprite = cutTree;
                stumpSR.gameObject.SetActive(true);
                
                //Add a random amount of wood

                woodValue.runtimeValue += gainedWood;
                onPickWood.Raise();
                Debug.Log(woodValue.runtimeValue);
                gainedWood = 0;
                Fall();
            }
        }
    }

    public bool CanInteract()
    {
        return isGrown;
    }

    //*******/ ANIMATIONS /*******//

    private void Shake()
    {
        transform.DOShakeRotation(1f, shakeStrength);
    }

    private void Fall()
    {
        float[] randRot = { 90f, -90f };

        sequence = DOTween.Sequence();

        sequence.Append(treeSR.transform.DOShakeRotation(1f, shakeStrength * 0.5f));
        sequence.Append(treeSR.transform
            .DORotate(new Vector3(0f, 0f, randRot[Random.Range(0, randRot.Length)]), fallDuration)
            .SetEase(Ease.InExpo));
        sequence.Append(treeSR.DOFade(0f, 1f).SetDelay(1f).SetEase(Ease.InOutSine));
    }
}