using System;
using Game.Player;
using UnityEngine;

public enum Drops
{
    Map,
    Platinum,
    Gold,
    Silver, 
    Bronze,
    Key,
}

public class Chest : BaseInteractable
{
    private Animator anim;
    [SerializeField] private string knotName;
    [SerializeField] private Drop chestLoot;
    private readonly int Open = Animator.StringToHash("Open");
    
    private OnEnterDialogueEvent onEnterDialogueEvent;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public override void Interact(Transform interactTransform)
    {
        isInteractable = false;
        anim.SetTrigger(Open);
        if (chestLoot == null)
            return;

        if (knotName != null)
        {
            onEnterDialogueEvent = new OnEnterDialogueEvent(knotName);
            EventBus.Raise(onEnterDialogueEvent);
        }

        if (chestLoot as UsableDrop)
        {
            UsableDrop drop = (UsableDrop)chestLoot;
            drop.Use();
        }
        interactTransform.gameObject.GetComponent<PlayerInventory>().AddItem(chestLoot);
    }
}