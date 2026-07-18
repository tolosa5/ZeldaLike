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
            Debug.Log(rock.gameObject.name + " entered pressure plate");
            onPressurePlatePressed = new OnPressurePlatePressed(id);
            EventBus.Raise(onPressurePlatePressed);
        }
    }
}