using System;
using UnityEngine;

public class EntityHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private int maxHealth = 6;
    private int currentHealth;
    public int CurrentHealth => currentHealth;

    [SerializeField] private bool isPlayer;
    
    [SerializeField] private Animator anim;
    public Animator Anim => anim;
    
    private CameraShakeEffect cameraShakeEffect;
    private readonly int GetHit = Animator.StringToHash("GetHit");
    
    private OnPlayerDeathEvent onPlayerDeathEvent;
    private OnEnemyDeathEvent onEnemyDeathEvent;
    private OnUpdateHealthUIEvent onUpdateHealthUIEvent;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    private void Start()
    {
        UpdateHealthUI();
    }

    public void HandleHit(GameObject source, float damage)
    {
        currentHealth -= (int)damage;
        if (isPlayer)
            UpdateHealthUI();
        
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            HandleDeath();
        }

        if (!anim) 
            return;
            
        StopAllCoroutines();
        PlayFeedback();
        //PlayParticles();
        anim.SetTrigger(GetHit);
    }

    private void HandleDeath()
    {
        if (isPlayer)
        {
            OnPlayerDeathEvent playerDeathEvent = new OnPlayerDeathEvent();
            EventBus.Raise(playerDeathEvent);
        }
        else
        {
            OnEnemyDeathEvent enemyDeathEvent = new OnEnemyDeathEvent();
            EventBus.Raise(enemyDeathEvent);
        }
    }

    private void UpdateHealthUI()
    {
        onUpdateHealthUIEvent = new OnUpdateHealthUIEvent(currentHealth, maxHealth);
        EventBus.Raise(onUpdateHealthUIEvent);
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
