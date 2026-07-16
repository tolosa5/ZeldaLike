
using UnityEngine;

[CreateAssetMenu(fileName = "Map", menuName = "Scriptable Objects/UsableDrop/Map")]
public class Map : UsableDrop
{
    private OnGetMapEvent onGetMapEvent;
    
    public override void Use()
    {
        onGetMapEvent = new OnGetMapEvent();
        EventBus.Raise(onGetMapEvent);
    }
}