using System;
using UnityEngine;

public class Chest : BaseInteractable
{
    private Animator anim;
    [SerializeField] private bool isLocked = false;
    [SerializeField] private Drop chestLoot;
    private readonly int Open = Animator.StringToHash("Open");

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        isInteractable = isLocked;
    }

    public override void Interact(Transform interactTransform)
    {
        isInteractable = false;
        anim.SetTrigger(Open);
        if (chestLoot == null) 
            return;
        
        if (chestLoot as UsableDrop)
        {
            UsableDrop drop = (UsableDrop)chestLoot;
            drop.Use();
        }
        interactTransform.gameObject.GetComponent<PlayerInventory>().AddItem(chestLoot);
    }
}