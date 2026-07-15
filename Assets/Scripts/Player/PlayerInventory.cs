using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private List<Key> keys = new();
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
