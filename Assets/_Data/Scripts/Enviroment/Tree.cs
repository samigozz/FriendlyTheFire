using UnityEngine;
using DG.Tweening;
public class Tree : MonoBehaviour, IInteractable
{
    [SerializeField] SpriteRenderer treeSR, stumpSR;
    private bool isGrown =true;

    private int health = 3;

    [Header("Animation")]

    [SerializeField] Vector3 shakeStrength;

    SpriteRenderer sr;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        stumpSR.gameObject.SetActive(false);
    }

    public void Interact()
    {
        Shake();
        health--;
        Debug.Log("Hit");
        if (health <= 0)
        {
            stumpSR.gameObject.SetActive(true);
            treeSR.gameObject.SetActive(false);
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
       
    }
}
