using System;
using UnityEngine;

namespace Game.Player
{
    public class PlayerCombat : MonoBehaviour, IDamageable
    {
        [SerializeField] private Animator anim;
        public Animator Anim => anim;
        [HideInInspector] public EntityAttack entityAttack;
        
        [SerializeField, Range(0, 1)]
        private float volume = 0.8f;
        [SerializeField] private ParticleSystem slashEffect;
        private CameraShakeEffect cameraShakeEffect;
        [SerializeField] private Transform cameraTransform;
        
        private readonly int Attack1 = Animator.StringToHash("Attack");
        private readonly int GetHit = Animator.StringToHash("GetHit");

        private void Awake()
        {
            entityAttack = GetComponent<EntityAttack>();
        }

        private void Start()
        {
            cameraShakeEffect = new CameraShakeEffect(cameraTransform);
        }

        public void Attack()
        {
            anim.SetTrigger(Attack1);
            PlayParticles(slashEffect);
        }

        public void HandleHit(GameObject source, float damage)
        {
            if (!anim) 
                return;
            
            StopAllCoroutines();
            PlayFeedback();
            //PlayParticles();
            anim.SetTrigger(GetHit);
        }

        private void PlayParticles(ParticleSystem particles)
        {
            if (particles) 
                particles.Play();
        }

        private void PlayFeedback()
        {
            cameraShakeEffect.StartShake();
        }
    }
}
