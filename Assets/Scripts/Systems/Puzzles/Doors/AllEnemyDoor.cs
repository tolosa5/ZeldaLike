using UnityEngine;

public class AllEnemyDoor : Door
{
    [SerializeField] private int id;
    
    private void Start()
    {
        EventBus.Subscribe<OnEnemiesDefeatedEvent>(EnemyOpen);
    }
    
    private void EnemyOpen(OnEnemiesDefeatedEvent data)
    {
        if (data.id != id)
            return;
        
        OpenDoor();
    }
}