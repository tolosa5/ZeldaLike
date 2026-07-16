using System;
using UnityEngine;

public class PusheableRock : MonoBehaviour
{
    public void LockPosition()
    {
        gameObject.isStatic = true;
    }
}