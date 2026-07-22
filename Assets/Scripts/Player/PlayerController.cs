using Game.Inputs;
using UnityEngine;

namespace Game.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerMovement playerMovement;
        [SerializeField] private PlayerCombat playerCombat;
        [SerializeField] private PlayerInteraction playerInteraction;
        
        private bool isMovementEnabled = true;

        private void Start()
        {
            InputManager.instance.inputSystemActions.Player.Attack.performed += ctx => playerCombat.Attack();
            InputManager.instance.inputSystemActions.Player.Interact.performed += ctx => playerInteraction.LookForInteraction();
            InputManager.instance.inputSystemActions.Player.Bow.performed += ctx => playerCombat.entityAttack.ShootArrow();
            
            EventBus.Subscribe<OnSwitchPlayerMovementEvent>(SwitchPlayerMovement);
        }

        private void Update()
        {
            if (playerCombat.Anim.GetCurrentAnimatorStateInfo(0).IsName("Player@Attack"))
                return;
            if (!isMovementEnabled)
                return;
            
            Vector2 movementInput = InputManager.instance.inputSystemActions.Player.Move.ReadValue<Vector2>();
            playerMovement.Move(movementInput);
        }

        private void SwitchPlayerMovement(OnSwitchPlayerMovementEvent data)
        {
            isMovementEnabled = !isMovementEnabled;
        }
    }
}
