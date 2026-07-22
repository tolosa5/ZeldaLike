using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyZone : MonoBehaviour
{
    [SerializeField] private int id;
    [SerializeField] private List<GameObject> enemies = new();
    private int totalEnemies = 0;
    
    private OnEnemiesZoneClearedEvent onEnemiesZoneClearedEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            ActivateEnemyZone();
    }

    private void Start()
    {
        SetUp();
        EventBus.Subscribe<OnEnemyDeathEvent>(EnemyDefeated);
    }

    private void SetUp()
    {
        totalEnemies = enemies.Count;
        foreach (var enemy in enemies)
        {
            enemy.SetActive(false);
        }
    }

    private void ActivateEnemyZone()
    {
        foreach (var enemy in enemies)
        {
            enemy.SetActive(true);
        }
    }

    private void EnemyDefeated(OnEnemyDeathEvent eventData)
    {
        totalEnemies--;
        if (totalEnemies <= 0)
            EnemyZoneCleared();
    }

    private void EnemyZoneCleared()
    {
        onEnemiesZoneClearedEvent = new OnEnemiesZoneClearedEvent(id);
        EventBus.Raise(onEnemiesZoneClearedEvent);
    }
}
