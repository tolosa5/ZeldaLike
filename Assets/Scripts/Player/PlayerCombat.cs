using System;
using UnityEngine;

namespace Game.Player
{
    public class PlayerCombat : MonoBehaviour, IDamageable
    {
        [SerializeField] private Animator anim;
        [HideInInspector] public EntityAttack entityAttack;
        
        [SerializeField, Range(0, 1)]
        private float volume = 0.8f;
        //[SerializeField] private ParticleSystem impactParticles;
        private CameraShakeEffect cameraShakeEffect;
        private Transform cameraTransform;
        
        private static readonly int Attack1 = Animator.StringToHash("Attack");

        private void Awake()
        {
            entityAttack = GetComponent<EntityAttack>();
        }

        private void Start()
        {
            cameraTransform = Camera.main.transform;
            cameraShakeEffect = new CameraShakeEffect(cameraTransform);
        }

        public void Attack()
        {
            anim.SetTrigger(Attack1);
        }

        public void HandleHit(GameObject source, float damage)
        {
            if (anim != null)
            {
                // Start rotation
                StopAllCoroutines();
                
            
                PlayFeedback();
                PlayParticles();
                anim.SetTrigger("GetHit");
            }
        }

        private void PlayParticles()
        {
            /*
            if (impactParticles != null)
                impactParticles.Play();
                */
        }

        private void PlayFeedback()
        {
            cameraShakeEffect.StartShake();
        }
    }
}
