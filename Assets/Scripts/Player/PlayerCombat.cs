using System;
using UnityEngine;

namespace Game.Player
{
    public class PlayerCombat : MonoBehaviour
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
