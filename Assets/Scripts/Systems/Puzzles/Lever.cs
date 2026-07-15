using System;
using UnityEngine;

public class Lever : BaseInteractable
{
    [SerializeField] private int id;
    private OnActivateLeverEvent onActivateLeverEvent;

    private void Awake()
    {
        tooltip = "Press E to pull the lever";
    }

    public override void Interact(Transform interactTransform)
    {
        onActivateLeverEvent = new OnActivateLeverEvent(id);
        EventBus.Raise(onActivateLeverEvent);
    }
}
