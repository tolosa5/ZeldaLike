using UnityEngine;

public class LeverDoor : Door
{
    [SerializeField] private int id;
    
    private void Start()
    {
        EventBus.Subscribe<OnActivateLeverEvent>(LeverOpen);
    }
    
    private void LeverOpen(OnActivateLeverEvent data)
    {
        if (data.id != id)
            return;
        
        Debug.Log("Lever Open id: " + data.id);
        OpenDoor();
    }
}
