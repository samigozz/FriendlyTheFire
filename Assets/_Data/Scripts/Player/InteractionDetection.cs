using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionDetection : MonoBehaviour
{
    private List<IInteractable> interactablesInRange = new List<IInteractable>();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && interactablesInRange.Count > 0)
        {
            var interactable = interactablesInRange[0];
            interactable.Interact();
            if (!interactable.CanInteract())
            {
                interactablesInRange.Remove(interactable);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var interactable = collision.GetComponent<IInteractable>();

        if (interactable != null && interactable.CanInteract())
        {
            Debug.Log("Interactable found.");
            interactablesInRange.Add(interactable);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var interactable = collision.GetComponent<IInteractable>();

        if (interactablesInRange.Contains(interactable))
        {
            interactablesInRange.Remove(interactable);
        }
    }
}
