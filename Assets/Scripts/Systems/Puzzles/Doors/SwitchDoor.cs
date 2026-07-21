using UnityEngine;

public class SwitchDoor : Door
{
    [SerializeField] private int id;
    
    private void Start()
    {
        EventBus.Subscribe<OnSwitchHit>(SwitchOpen);
    }
    
    private void SwitchOpen(OnSwitchHit data)
    {
        if (data.id != id)
            return;
        
        OpenDoor();
    }
}