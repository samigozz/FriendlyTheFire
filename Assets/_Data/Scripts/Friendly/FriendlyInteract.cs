using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Slider = UnityEngine.UI.Slider;

public class FriendlyInteract : MonoBehaviour, IInteractable
{
    [SerializeField]
    private GameObject FLife;
    
    private int wood = 3;

    public void Interact()
    {
        print("entra");
        wood--;
        FLife.gameObject.GetComponent<Slider>().value += 0.03f;
    }

    public bool CanInteract()
    {
        if (wood > 0)
        {
            return true;
        }

        return false;
    }
}
