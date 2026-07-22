using System;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private float speed;
    private float lifeTime = 3f;
    
    public void Initialize(GameObject source)
    {
        transform.rotation = Quaternion.Euler(0f, source.transform.eulerAngles.y, 0f);
        transform.Translate(transform.forward * (speed  * Time.deltaTime));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (TryGetComponent(out IDamageable damageable))
            damageable.HandleHit(gameObject, 2f);
    }

    private void Update()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0f)
            ObjectPooler.EnqueueObject(this, "Arrow");
    }
}
