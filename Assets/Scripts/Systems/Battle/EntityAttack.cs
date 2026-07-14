using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityAttack : MonoBehaviour
{
    [SerializeField] private float damage = 10f;
    [SerializeField] private float attackRadius = 1f;
    [SerializeField] private Transform attackSpot;

    [HideInInspector] public bool isAttacking;
    
    private Collider[] buffer = new Collider[15];
    private List<IDamageable> alreadyDamaged = new List<IDamageable>();
    
    //Animator call
    public void OpenAttackWindow()
    {
        alreadyDamaged.Clear();
        isAttacking = true;
        StartCoroutine(Damaging());
    }
    
    private IEnumerator Damaging()
    {
        Debug.Log("Performing hit");
        int results = Physics.OverlapSphereNonAlloc(attackSpot.position, attackRadius, buffer);
        if (results <= 0)
            yield return null;

        for (int i = 0; i < results; i++)
        {
            if (buffer[i].TryGetComponent(out IDamageable damageable) && 
                !alreadyDamaged.Contains(damageable))
            {
                damageable.HandleHit(gameObject, damage);
                alreadyDamaged.Add(damageable);
            }
        }
    }

    public void CloseAttackWindow()
    {
        isAttacking = false;
        StopAllCoroutines();
    }
}
