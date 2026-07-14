using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "DamagingTargetAction", story: "[Self] is damaging targets", category: "Action", id: "927f960ac8282d49cbc392d6a7fd1fd3")]
public partial class DamagingTargetAction : Action
{
    [SerializeReference] public BlackboardVariable<EntityAttack> Self;
    [SerializeReference] public BlackboardVariable<EmptyEventChannel> OnAttackWindowOpen;
    [SerializeReference] public BlackboardVariable<EmptyEventChannel> OnAttackWindowClose;
    [SerializeReference] public BlackboardVariable<EmptyEventChannel> OnAttackWindowEnd;

    protected override Status OnStart()
    {
        OnAttackWindowOpen.Value.Event += OpenWindow;
        OnAttackWindowClose.Value.Event += CloseWindow;
        OnAttackWindowEnd.Value.Event += FinishAction;
        return Status.Running;
    }

    private void OpenWindow()
    {
        Self.Value.OpenAttackWindow();
    }

    private void CloseWindow()
    {
        Self.Value.CloseAttackWindow();
    }

    private void FinishAction()
    {
        OnAttackWindowOpen.Value.Event -= OpenWindow;
        OnAttackWindowClose.Value.Event -= CloseWindow;
        OnAttackWindowEnd.Value.Event -= FinishAction;
        EndNode(this);
    }
}

