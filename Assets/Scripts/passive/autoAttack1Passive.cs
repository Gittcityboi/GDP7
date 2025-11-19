using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoAttack1Passive : MonoBehaviour
{
    public GameObject player;
    public GameObject autoAttack1_prefab;

    float cool_time = 5;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
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
            //game_manager.AddComponent(this.GetType());
            var support = player.AddComponent(this.GetType()) as autoAttack1Passive;
            support.autoAttack1_prefab = GetComponent<autoAttack1Passive>().autoAttack1_prefab;
        }
    }

    public void UsePassive()
    {
        StartCoroutine(autoATtack());
    }

    public void OffPassive()
    {

    }

    void OnPlayerHitEvent_reflection(GameObject other, float damage)
    {

    }

    private IEnumerator autoATtack()
    {
        yield return new WaitForSeconds(cool_time);
        StartCoroutine(autoATtack());
    }
}
