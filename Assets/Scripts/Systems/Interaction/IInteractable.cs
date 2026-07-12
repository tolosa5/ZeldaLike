
using UnityEngine;

public interface IInteractable
{
    public void Interact(Transform interactTransform);
    public string GetTooltipText();
    public bool GetIsInteractable();
}
