using System;
using UnityEngine;

public class PusheableRock : MonoBehaviour
{
    public void LockPosition()
    {
        transform.parent.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    }
}