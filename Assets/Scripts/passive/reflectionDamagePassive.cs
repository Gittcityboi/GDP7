using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reflectionDamagePassive : MonoBehaviour,Passive
{
    public GameObject player;
    public GameObject game_manager;

    public GameObject reflection_prefab;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        game_manager = GameObject.FindWithTag("gameManager");
        if (this.gameObject == player)
        {
            game_manager.GetComponent<eventManager>().OnPlayerHitEvent += OnPlayerHitEvent_reflection;
            //StartCoroutine(Passive());
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
            //game_manager.AddComponent(this.GetType());
            var support = player.AddComponent(this.GetType()) as reflectionDamagePassive;
            support.reflection_prefab = GetComponent<reflectionDamagePassive>().reflection_prefab;
        }
    }

    public void UsePassive()
    {

    }

    public void OffPassive()
    {

    }

    void OnPlayerHitEvent_reflection(GameObject other, float damage)
    {
        GameObject reflection_object = Instantiate(reflection_prefab, player.transform) as GameObject;
        reflection_object.GetComponent<playerAttack>().damage = damage * 2;
    }

    //private IEnumerator Passive()
    //{
    //game_manager.GetComponent<eventManager>().OnEnemyHitEvent += OnEnemyHitEvent_poison;
    //yield return new WaitForSeconds(valid_time);
    //game_manager.GetComponent<eventManager>().OnEnemyHitEvent -= OnEnemyHitEvent_poison;
    //Destroy(this);
    //}
}
