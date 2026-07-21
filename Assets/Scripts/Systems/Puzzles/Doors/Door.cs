using System;
using UnityEngine;

public class Door : BaseInteractable
{
    protected void OpenDoor()
    {
        gameObject.SetActive(false);
    }

    public override void Interact(Transform interactTransform)
    {
        if (isInteractable)
            OpenDoor();
    }
}