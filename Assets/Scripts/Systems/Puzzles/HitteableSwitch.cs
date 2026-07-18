using Game.Player;
using UnityEngine;

public class HitteableSwitch : MonoBehaviour, IDamageable
{
    [SerializeField] private int id;
    private OnSwitchHit onSwitchHit;
    
    public void HandleHit(GameObject source, float damage)
    {
        Debug.Log(gameObject.name + " was hit by " + source.name);
        
        if (!source.TryGetComponent(out PlayerCombat playerCombat)) 
            return;
        onSwitchHit = new OnSwitchHit(id);
        EventBus.Raise(onSwitchHit);
    }
}
