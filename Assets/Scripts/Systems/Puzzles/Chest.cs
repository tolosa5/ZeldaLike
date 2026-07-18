using System;
using Game.Player;
using UnityEngine;

public class Chest : BaseInteractable
{
    private Animator anim;
    [SerializeField] private string knotName;
    [SerializeField] private Drop chestLoot;
    private readonly int Open = Animator.StringToHash("Open");
    
    private OnEnterDialogue onEnterDialogue;

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
            onEnterDialogue = new OnEnterDialogue(knotName);
            EventBus.Raise(onEnterDialogue);
        }

        if (chestLoot as UsableDrop)
        {
            UsableDrop drop = (UsableDrop)chestLoot;
            drop.Use();
        }
        interactTransform.gameObject.GetComponent<PlayerInventory>().AddItem(chestLoot);
    }
}