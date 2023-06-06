using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour, IInteractable
{
    [SerializeField] Sprite grownsprite, cutSprite;
    private bool isGrown =true;

    SpriteRenderer sr;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = grownsprite;
    }

    public void Interact()
    {
        Debug.Log("Cut.");
        sr.sprite = cutSprite;
        isGrown = false;
    }
    public bool CanInteract()
    {
        return isGrown;
    }
}
