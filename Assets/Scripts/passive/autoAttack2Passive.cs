using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoAttack2Passive : MonoBehaviour,Passive
{    
    public float angularSpeed = 3f;     
    public float angle = 0f;     
    public float radius = 3f;     

    public GameObject player;
    public GameObject autoAttack2_prefab;
    GameObject attack = null;


    void Start()
    {
        player = GameObject.FindWithTag("Player");
        if (this.gameObject == player)
        {
            UsePassive();
        }
    }

    void Update()
    {
        if(attack != null)
        {
            angle += angularSpeed * Time.deltaTime;

            float x = player.transform.position.x + Mathf.Cos(angle) * radius;
            float y = player.transform.position.y + Mathf.Sin(angle) * radius;

            attack.transform.position = new Vector3(x, y, transform.position.z);
        }
    }
    public void AddPassive()
    {
        if (player.GetComponent(this.GetType()) == null)
        {
            //game_manager.AddComponent(this.GetType());
            var support = player.AddComponent(this.GetType()) as autoAttack2Passive;
            support.autoAttack2_prefab = GetComponent<autoAttack2Passive>().autoAttack2_prefab;
        }
    }

    public void UsePassive()
    {
        attack = Instantiate(autoAttack2_prefab, player.transform.position, Quaternion.identity) as GameObject;
        attack.transform.position = player.transform.position + new Vector3(radius, 0, 0);
    }

    public void OffPassive()
    {

    }
}
