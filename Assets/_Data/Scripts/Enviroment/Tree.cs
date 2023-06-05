using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour, IInteractable
{
    private bool isGrown;

    public void Interact()
    {
        throw new System.NotImplementedException();
    }
    public bool CanInteract()
    {
        return isGrown;
    }
}
