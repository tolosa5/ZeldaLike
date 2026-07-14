using UnityEngine;

public class AnimationSystem : MonoBehaviour
{
    [SerializeField] private EmptyEventChannel attackWindowOpenChannel;
    [SerializeField] private EmptyEventChannel attackWindowCloseChannel;
    [SerializeField] private EmptyEventChannel attackEndChannel;
    
    private void OnAttackWindowOpen()
    {
        attackWindowOpenChannel.SendEventMessage();
    }

    private void OnAttackWindowClose()
    {
        attackWindowCloseChannel.SendEventMessage();
    }

    private void OnAttackWindowEnd()
    {
        attackEndChannel.SendEventMessage();
    }
}
