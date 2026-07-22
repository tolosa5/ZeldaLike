using UnityEngine;

public class AllEnemyDoor : Door
{
    [SerializeField] private int id;
    
    private void Start()
    {
        EventBus.Subscribe<OnEnemiesZoneClearedEvent>(EnemyOpen);
    }
    
    private void EnemyOpen(OnEnemiesZoneClearedEvent data)
    {
        if (data.id != id)
            return;
        
        OpenDoor();
    }
}