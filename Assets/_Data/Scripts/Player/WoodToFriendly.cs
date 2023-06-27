using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodToFriendly : MonoBehaviour
{
    private List<IInteractable> interactablesInRange = new List<IInteractable>();

    // Update is called once per frame
    void Update()
    {
        print("interactaleinrabge " + interactablesInRange.Count);
        if (Input.GetKeyDown(KeyCode.E) && interactablesInRange.Count > 0)
        {
            var interactable = interactablesInRange[0];
            
            if (!interactable.CanInteract())
            {
                interactablesInRange.Remove(interactable);
            }
            
            interactable.Interact();
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var interactable = collision.GetComponent<IInteractable>();
        
        if (interactable != null && interactable.CanInteract())
        {
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
