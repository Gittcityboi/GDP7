using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class criticalPassive : MonoBehaviour, Passive
{
    public GameObject player;
    public GameObject game_manager;

    public int critical_percent = 150;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        game_manager = GameObject.FindWithTag("gameManager");
        if (this.gameObject == player)
        {
            UsePassive();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddPassive()
    {
        if (player.GetComponent(this.GetType()) == null)
        {
            player.AddComponent(this.GetType());
        }
    }

    public void UsePassive()
    {
        game_manager.GetComponent<eventManager>().OnEnemyHitEvent += OnEnemyHitEvent_critical;
    }

    public void OffPassive()
    {
        game_manager.GetComponent<eventManager>().OnEnemyHitEvent -= OnEnemyHitEvent_critical;
    }

    void OnEnemyHitEvent_critical(GameObject other, float damage)
    {
        int seed = System.DateTime.Now.Millisecond;
        System.Random critical = new System.Random(seed);
        int hit = critical.Next(0, 1000);
        Debug.Log(hit);
        if (hit < critical_percent)
        {
            Debug.Log("critical hit");
            other.GetComponent<enemyScript>().damaged(damage);
        }
    }
}
