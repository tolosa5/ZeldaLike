using UnityEngine;

public class SwitchDoor : Door
{
    [SerializeField] private int id;
    
    private void Start()
    {
        EventBus.Subscribe<OnSwitchHitEvent>(SwitchOpen);
    }
    
    private void SwitchOpen(OnSwitchHitEvent data)
    {
        if (data.id != id)
            return;
        
        OpenDoor();
    }
}