using System;
using UnityEngine;

public class Chest : BaseInteractable
{
    private Animator anim;
    [SerializeField] private bool isLocked = false;
    [SerializeField] private Loot chestLoot;
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
        anim.SetTrigger(Open);
        if (chestLoot != null)
        {
            
        }
    }
}