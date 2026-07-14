using UnityEngine;

public abstract class BaseInteractable : MonoBehaviour, IInteractable
{
    protected string tooltip = "";
    [SerializeField] protected bool isInteractable = true;

    public abstract void Interact(Transform interactTransform);

    public string GetTooltipText()
    {
        return tooltip;
    }

    public bool GetIsInteractable()
    {
        return isInteractable;
    }
}
