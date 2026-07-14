using UnityEngine;

public class EnemyCombat : MonoBehaviour, IDamageable
{
    [SerializeField] private Animator anim;
    
    private readonly int Attack1 = Animator.StringToHash("Attack");
    private readonly int GetHit = Animator.StringToHash("GetHit");
    
    public void HandleHit(GameObject source, float damage)
    {
        Debug.Log(source.name + " hit!");
        if (anim != null)
        {
            // Start rotation
            StopAllCoroutines();
                
            PlayFeedback();
            PlayParticles();
            anim.SetTrigger(GetHit);
        }
    }
    
    private void PlayParticles()
    {
        /*
        if (impactParticles != null)
            impactParticles.Play();
            */
    }

    private void PlayFeedback()
    {
        //cameraShakeEffect.StartShake();
    }
}
