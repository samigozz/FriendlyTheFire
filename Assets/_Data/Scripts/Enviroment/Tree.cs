using UnityEngine;
using DG.Tweening;
public class Tree : MonoBehaviour, IInteractable
{
    [SerializeField] SpriteRenderer treeSR, stumpSR;
    [SerializeField] Sprite fullTree, cutTree;
    private bool isGrown =true;

    private int health = 3;

    [Header("Animation")]

    [SerializeField] Vector3 shakeStrength;

    [SerializeField] float fallDuration = 1f;  

    Sequence sequence;

    private void Start()
    {
        stumpSR.gameObject.SetActive(false);
    }

    public void Interact()
    {
        Shake();
        health--;
        if (health <= 0)
        {
            treeSR.sprite = cutTree;
            Fall();
            stumpSR.gameObject.SetActive(true);
            isGrown = false;
        }

    }
    public bool CanInteract()
    {
        return isGrown;
    }

    private void Shake()
    {
        transform.DOShakeRotation(1f, shakeStrength);
    }

    private void Fall()
    {
        float[] randRot = { 90f, -90f };

        sequence = DOTween.Sequence();

        sequence.Append(treeSR.transform.DORotate(new Vector3(0f, 0f, randRot[Random.Range(0,randRot.Length)]), fallDuration).SetEase(Ease.InExpo));
        sequence.Append(treeSR.DOFade(0f, 1f).SetDelay(1f).SetEase(Ease.InOutSine));
    }
}
