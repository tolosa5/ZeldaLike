using System;
using UnityEngine;

public class Door : BaseInteractable
{
    protected void OpenDoor()
    {
        
    }

    public override void Interact(Transform interactTransform)
    {
        OpenDoor();
    }
}
