using UnityEngine;

public class LeverDoor : Door
{
    [SerializeField] private int id;
    
    private void Start()
    {
        EventBus.Subscribe<ActivateLeverEvent>(LeverOpen);
    }
    
    private void LeverOpen(ActivateLeverEvent data)
    {
        if (data.id != id)
            return;
        
        Debug.Log("Lever Open id: " + data.id);
        OpenDoor();
    }
}
