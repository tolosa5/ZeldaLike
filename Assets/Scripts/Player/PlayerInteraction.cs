using UnityEngine;

namespace Game.Player
{
    public class PlayerInteraction : MonoBehaviour
    {
        [SerializeField] private Transform interactTransform;
        [SerializeField] private LayerMask interactableMask;
        [SerializeField] private float interactionSize;
        
        OnActivateTooltipEvent onOnActivateTooltipEvent;
        OnDeactivateTooltipEvent onOnDeactivateTooltipEvent;

        private void Update()
        {
            IInteractable interactable = GetInteractableObject();

            if (interactable != null && interactable.GetIsInteractable())
            {
                onOnActivateTooltipEvent = new OnActivateTooltipEvent(interactable.GetTooltipText());
                EventBus.Raise(onOnActivateTooltipEvent);
            }
            else
            {
                onOnDeactivateTooltipEvent = new OnDeactivateTooltipEvent();
                EventBus.Raise(onOnDeactivateTooltipEvent);
            }
        }

        private IInteractable GetInteractableObject()
        {
            Collider[] colls = Physics.OverlapSphere(interactTransform.position, 
                interactionSize, interactableMask);

            if (colls.Length <= 0) 
                return null;
        
            return colls[0].gameObject.TryGetComponent(
                out IInteractable interactable) ? interactable : null;
        }
        
        public void LookForInteraction()
        {
            IInteractable interactable = GetInteractableObject();
            if (!interactable.GetIsInteractable())
                return;
            
            interactable?.Interact(transform);
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawSphere(interactTransform.position, 0.5f);
        }
    }
}
