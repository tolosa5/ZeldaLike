using System;
using UnityEngine;

public class Lever : BaseInteractable
{
    [SerializeField] private int id;
    private ActivateLeverEvent activateLeverEvent;

    private void Awake()
    {
        tooltip = "Press E to pull the lever";
    }

    public override void Interact(Transform interactTransform)
    {
        activateLeverEvent = new ActivateLeverEvent(id);
        EventBus.Raise(activateLeverEvent);
    }
}
