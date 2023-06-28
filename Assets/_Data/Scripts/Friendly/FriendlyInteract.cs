using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Slider = UnityEngine.UI.Slider;

public class FriendlyInteract : MonoBehaviour, IInteractable
{
    [SerializeField]
    private GameObject FLife;

    [SerializeField] private IntValue wood;
    [SerializeField] private GameEvent onUpdateWood;

    public void Interact()
    {
        wood.runtimeValue--;
        FLife.gameObject.GetComponent<Slider>().value += 0.01f;
        onUpdateWood.Raise();
    }

    public bool CanInteract()
    {
        if (wood.runtimeValue > 1)
        {
            return true;
        }

        return false;
    }
}
