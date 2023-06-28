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
    [SerializeField] private float woodHeal = 0.012f;

    public void Interact()
    {
        wood.runtimeValue--;
        FLife.gameObject.GetComponent<Slider>().value += woodHeal;
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
