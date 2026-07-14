using UnityEngine;

public class SensorSystem : MonoBehaviour
{
    [SerializeField] private float sensorRadius;
    [SerializeField] private float sensorAngle;
    [SerializeField] private LayerMask isTarget;
    [SerializeField] private LayerMask isObstacle;
    
    private Collider[] buffer = new Collider[5];

    private void FixedUpdate()
    {
        SearchTarget();
    }

    public GameObject SearchTarget()
    {
        int results = Physics.OverlapSphereNonAlloc(transform.position, sensorRadius, buffer, isTarget);
        if (results > 0)
        {
            Vector3 directionToTarget = buffer[0].transform.position - transform.position;
            if (Vector3.Angle(directionToTarget, directionToTarget) < sensorAngle / 2)
            {
                if (!Physics.Raycast(transform.position + Vector3.up * .3f, 
                        directionToTarget, directionToTarget.magnitude, isObstacle))
                {
                    return buffer[0].gameObject;
                }
            }
        }
        return null;
    }
}
