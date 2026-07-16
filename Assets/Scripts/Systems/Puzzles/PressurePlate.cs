using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] private GameObject visualPlate;
    [SerializeField] private int id;
    
    private OnPressurePlatePressed onPressurePlatePressed;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PusheableRock rock))
        {
            rock.LockPosition();
            onPressurePlatePressed = new OnPressurePlatePressed(id);
            EventBus.Raise(onPressurePlatePressed);
        }
    }
}