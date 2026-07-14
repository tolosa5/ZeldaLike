using System;
using Unity.Behavior;
using UnityEngine;
using Unity.Properties;

#if UNITY_EDITOR
[CreateAssetMenu(menuName = "Behavior/Event Channels/_EmptyEventChannel")]
#endif
[Serializable, GeneratePropertyBag]
[EventChannelDescription(name: "_EmptyEventChannel", message: "Event", category: "Events", id: "35b54abeff00bd88161fb662f52a0604")]
public sealed partial class EmptyEventChannel : EventChannel { }

