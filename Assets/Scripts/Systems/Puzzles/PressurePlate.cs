using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] private GameObject visualPlate;
    [SerializeField] private int id;
    
    private OnPressurePlatePressedEvent onPressurePlatePressedEvent;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PusheableRock rock))
        {
            rock.LockPosition();
            Debug.Log(rock.gameObject.name + " entered pressure plate");
            onPressurePlatePressedEvent = new OnPressurePlatePressedEvent(id);
            EventBus.Raise(onPressurePlatePressedEvent);
        }
    }
}