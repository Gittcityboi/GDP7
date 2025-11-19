using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    float max_hp = 100f;
    public float hp;
    public float speed = 1f;
    public float hit_time = 0f;
    public float hit_time_save = 0f;
    public GameObject hit_object = null;
    public GameObject hp_bar;
    public GameObject hp_bar_red;
    GameObject player;
    GameObject gameManager;

    public float damage = 5f;

    // Start is called before the first frame update
    void Start()
    {
        hp = max_hp;
        player = GameObject.FindWithTag("Player");
        gameManager = GameObject.FindWithTag("gameManager");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.transform.position - transform.position;
        Vector3 move_vector = direction.normalized;
        transform.Translate(move_vector * speed);
        if(hit_time > 0f)
        {
            hit_time -= Time.deltaTime;
        }
        else if(hit_time < 0f)
        {
            hit_time = 0f;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("attack"))
        {
            //Debug.Log("hitEnter");
            hit_object = other.gameObject;

            hp -= other.GetComponent<playerAttack>().damage;
            hit_time = other.GetComponent<playerAttack>().hit_time;
            hit_time_save = other.GetComponent<playerAttack>().hit_time;
            gameManager.GetComponent<eventManager>().InvokeEnemyHitEvent(this.gameObject, other.GetComponent<playerAttack>().damage);
            //Debug.Log("hit");
            hp_bar.SetActive(true);
            if (hp <= 0)
            {
                hp = 0;
                hp_bar_red.transform.localScale = new Vector3(hp / max_hp, 1, 1);
                hp_bar_red.transform.localPosition = new Vector3((hp / max_hp - 1) / 2, 0, -2);
                //Debug.Log("dead");
                return;
            }
            hp_bar_red.transform.localScale = new Vector3(hp / max_hp, 1, 1);
            hp_bar_red.transform.localPosition = new Vector3((hp / max_hp - 1) / 2, 0, -2);
        }

    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("attack") && hit_time_save > other.GetComponent<playerAttack>().hit_time)
        {
            hit_time = 0;
        }
        if (other.CompareTag("attack") && (hit_time <= 0))//(hit_object == other.gameObject && hit_time <= 0) || (hit_object != other.gameObject)
        {
            hit_object = other.gameObject;
            
            hp -= other.GetComponent<playerAttack>().damage;
            hit_time = other.GetComponent<playerAttack>().hit_time;
            hit_time_save = other.GetComponent<playerAttack>().hit_time;
            gameManager.GetComponent<eventManager>().InvokeEnemyHitEvent(this.gameObject, other.GetComponent<playerAttack>().damage);
            //Debug.Log("hit");
            hp_bar.SetActive(true);
            if (hp <= 0)
            {
                hp = 0;
                hp_bar_red.transform.localScale = new Vector3(hp / max_hp, 1, 1);
                hp_bar_red.transform.localPosition = new Vector3((hp / max_hp - 1) / 2, 0, -2);
                //Debug.Log("dead");
                return;
            }
            hp_bar_red.transform.localScale = new Vector3(hp / max_hp, 1, 1);
            hp_bar_red.transform.localPosition = new Vector3((hp / max_hp - 1) / 2, 0, -2);

        }
    }

    public void damaged(float damage)
    {
        
        hp -= damage;
        hp_bar.SetActive(true);
        if (hp <= 0)
        {
            hp = 0;
            hp_bar_red.transform.localScale = new Vector3(hp / max_hp, 1, 1);
            hp_bar_red.transform.localPosition = new Vector3((hp / max_hp - 1) / 2, 0, -2);
            //Debug.Log("dead");
            return;
        }
        hp_bar_red.transform.localScale = new Vector3(hp / max_hp, 1, 1);
        hp_bar_red.transform.localPosition = new Vector3((hp / max_hp - 1) / 2, 0, -2);
    }
}
