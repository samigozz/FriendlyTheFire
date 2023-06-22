using UnityEngine;

public interface IInteractable 
{
    public void Interact(Transform player = default(Transform));
    
    public bool CanInteract();
}
