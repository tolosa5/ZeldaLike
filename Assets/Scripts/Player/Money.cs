using System;
using Game.Player;
using UnityEngine;

namespace Game.Resources
{
    public class Money : MonoBehaviour
    {
        [SerializeField] private Drop money;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.TryGetComponent(out PlayerInventory playerInventory)) 
                return;
            playerInventory.AddMoney(this);
            Destroy(gameObject);
        }
    }
}