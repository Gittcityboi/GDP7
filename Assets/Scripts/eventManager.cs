using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventManager : MonoBehaviour
{
    public delegate void OnHitDelegate(GameObject other);
    public event OnHitDelegate OnEnemyHitEvent;

    public void InvokeEnemyHitEvent(GameObject other)
    {
        OnEnemyHitEvent?.Invoke(other);
    }

}
