using UnityEngine;

public class EnemyLockedChest : Chest
{
    [SerializeField] private int id;
    [SerializeField] private ParticleSystem unlockEffect;
    
    private void Start()
    {
        isInteractable = false;
        EventBus.Subscribe<OnEnemiesZoneClearedEvent>(UnlockChest);
    }

    private void UnlockChest(OnEnemiesZoneClearedEvent data)
    {
        if (data.id == id)
            isInteractable = true;
        
        if (unlockEffect)
            unlockEffect.Play();
    }
}