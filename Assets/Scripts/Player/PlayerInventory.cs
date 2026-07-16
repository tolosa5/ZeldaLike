using System.Collections.Generic;
using Game.Resources;
using UnityEngine;

namespace Game.Player
{
    public class PlayerInventory : MonoBehaviour
    {
        private List<Key> keys = new();
        private List<Drop> inventory = new();
        private List<Money> moneyPouch = new();
        [SerializeField] private GameObject inventoryWrapper;

        private void Start()
        {
            EventBus.Subscribe<OnGetMapEvent>(GetMap);
        }

        public void SwitchInventoryState()
        {
            inventoryWrapper.SetActive(!inventoryWrapper.activeSelf);
        }

        public void AddItem(Drop loot)
        {
            inventory.Add(loot);
        }

        public void AddMoney(Money money)
        {
            Debug.Log("Adding money to pouch");
            moneyPouch.Add(money);
        }

        public void AddKey(Key key)
        {
            keys.Add(key);
        }

        public void RemoveKey(Key key)
        {
            keys.Remove(key);
        }

        private void GetMap(OnGetMapEvent data)
        {
            
        }
    
        public List<Key> GetKeys() { return keys; }
    }
}
