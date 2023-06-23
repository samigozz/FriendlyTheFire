using System;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Tree : MonoBehaviour, IInteractable
{
    private bool isGrown =true;
    private int health = 3;
    [Header("General")] 
    [SerializeField] private Transform cutPos;

    [Header("Sprites")] 
    [SerializeField] private SpriteRenderer treeSR;
    [SerializeField] private SpriteRenderer stumpSR;
    [SerializeField] private Sprite fullTree;
    [SerializeField] private Sprite cutTree;

    [Header("Animation")]
    [SerializeField] Vector3 shakeStrength;
    [SerializeField] float fallDuration = 1f;  
    Sequence sequence;

    [Header("Mini-games")] 
    [SerializeField] private Transform target;
    [SerializeField] private Transform pivot;

    [SerializeField] private GameObject rotatingMiniGame;

    [SerializeField, Range(0f, 1f)] private float reactThreshold = 0.97f;
    

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

        if (result >= reactThreshold || result <= -reactThreshold)
        {
            // Cutting tree animation and health.
            Shake();
            health--;
            
            if (health <= 0)
            {
                isGrown = false;
                rotatingMiniGame.SetActive(false);
                treeSR.sprite = cutTree;
                stumpSR.gameObject.SetActive(true);
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

        sequence.Append(treeSR.transform.DOShakeRotation(1f, shakeStrength*0.5f));
        sequence.Append(treeSR.transform.DORotate(new Vector3(0f, 0f, randRot[Random.Range(0,randRot.Length)]), fallDuration).SetEase(Ease.InExpo));
        sequence.Append(treeSR.DOFade(0f, 1f).SetDelay(1f).SetEase(Ease.InOutSine));
    }
}
