using UnityEngine;

namespace Game.Player
{
    public class PlayerInteraction : MonoBehaviour
    {
        [SerializeField] private Transform interactTransform;
        [SerializeField] private LayerMask interactableMask;
        [SerializeField] private float interactionSize;
        
        ActivateTooltipEvent onActivateTooltipEvent;
        DeactivateTooltipEvent onDeactivateTooltipEvent;

        private void Update()
        {
            IInteractable interactable = GetInteractableObject();

            if (interactable != null && interactable.GetIsInteractable())
            {
                onActivateTooltipEvent = new ActivateTooltipEvent(interactable.GetTooltipText());
                EventBus.Raise(onActivateTooltipEvent);
            }
            else
            {
                onDeactivateTooltipEvent = new DeactivateTooltipEvent();
                EventBus.Raise(onDeactivateTooltipEvent);
            }
        }

        private IInteractable GetInteractableObject()
        {
            Collider[] colls = Physics.OverlapSphere(interactTransform.position, 
                interactionSize, interactableMask);
            
            Debug.Log(colls.Length);

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
