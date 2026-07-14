using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private List<Key> keys = new();
    [SerializeField] private GameObject inventoryWrapper;

    private void Start()
    {
        
    }

    public void SwitchInventoryState()
    {
        inventoryWrapper.SetActive(!inventoryWrapper.activeSelf);
    }

    public void AddItem(Loot loot)
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
    
    public List<Key> GetKeys() { return keys; }
}
