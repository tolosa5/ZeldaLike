using UnityEngine;

public class KeyDoor : Door
{
    public override void Interact(Transform interactTransform)
    {
        if (!interactTransform.gameObject.TryGetComponent(out PlayerInventory playerInventory)) 
            return;
        
        if (playerInventory.GetKeys().Count <= 0) 
            return;
        
        playerInventory.RemoveKey(playerInventory.GetKeys()[0]);
        base.Interact(interactTransform);
    }
}
