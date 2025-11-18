using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventManager : MonoBehaviour
{
    public delegate void OnHitDelegate(GameObject other, float damage);
    public event OnHitDelegate OnEnemyHitEvent;

    public delegate void OnPlayerHitDelegate(GameObject other, float damage);
    public event OnPlayerHitDelegate OnPlayerHitEvent;

    public void InvokeEnemyHitEvent(GameObject other, float damage)
    {
        OnEnemyHitEvent?.Invoke(other, damage);
    }

    public void InvokeOnPlayerHitEvent(GameObject other, float damage)
    {
        OnPlayerHitEvent?.Invoke(other, damage);
    }
}
