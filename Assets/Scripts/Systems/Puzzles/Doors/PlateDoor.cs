using UnityEngine;

public class PlateDoor : Door
{
    [SerializeField] private int id;

    private void Start()
    {
        EventBus.Subscribe<OnActivateLeverEvent>(PlateOpen);
    }

    private void PlateOpen(OnActivateLeverEvent data)
    {
        if (data.id != id)
            return;

        OpenDoor();
    }
}