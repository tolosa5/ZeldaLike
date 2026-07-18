using System;
using UnityEngine;

namespace Game.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [Range(1, 5)]
        [SerializeField] private float rotationSpeed = 1f;
        [SerializeField] private float playerSpeed = 2f;
        [Range(1, 5)] 
        [SerializeField] private float pushForce = 2f;
        
        private CharacterController controller;
        private Transform mainCam;
        [SerializeField] private GameObject playerVisuals;
    
        private bool isPlayerGrounded;
        private Vector3 playerVelocity;
        
        private void Awake()
        {
            controller = GetComponent<CharacterController>();
            mainCam = Camera.main.transform;
        }

        private void OnControllerColliderHit(ControllerColliderHit hit)
        {
            Rigidbody rb = hit.collider.attachedRigidbody;
            if (rb == null || rb.isKinematic)
                return;

            if (hit.moveDirection.y < -0.3f)
                return;
            
            Vector3 forceDirection = hit.gameObject.transform.position - transform.position;
            forceDirection.y = 0;
            forceDirection.Normalize();
            
            rb.AddForceAtPosition(forceDirection * pushForce, transform.position, ForceMode.Impulse);
        }

        public void Move(Vector2 movementInput)
        {
            isPlayerGrounded = controller.isGrounded;
            
            if (isPlayerGrounded && playerVelocity.y < 0)
                playerVelocity.y = 0f;
            
            Vector3 move = new Vector3(movementInput.x, 0, movementInput.y);
            move.y = 0;
        
            controller.Move(move * (playerSpeed * Time.deltaTime));
        
            if (move != Vector3.zero)
                gameObject.transform.forward = move;

            if (movementInput != Vector2.zero)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(move), rotationSpeed * Time.deltaTime);
            }
        }
    }
}
