using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "SearchingAction", story: "[Self] is searching for [Target]", category: "Action", id: "62f4f3e0e89b83ea086f75b883910b08")]
public partial class SearchingAction : Action
{
    [SerializeReference] public BlackboardVariable<SensorSystem> Self;
    [SerializeReference] public BlackboardVariable<GameObject> Target;
    [SerializeReference] public BlackboardVariable<Vector3> LastKnownPosition;

    protected override Status OnUpdate()
    {
        GameObject possibleTarget = Self.Value.SearchTarget();

        if (Target.Value == null && possibleTarget != null)
        {
            Target.Value = possibleTarget;
            return Status.Success;
        }

        if (Target.Value != null && possibleTarget == null)
        {
            LastKnownPosition.Value = Target.Value.transform.position;
            Target.Value = null;
            return Status.Failure;
        }
        
        return Status.Running;
    }
}

