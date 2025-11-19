using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getawayPassive : MonoBehaviour, Passive
{
    public GameObject player;
    public GameObject game_manager;

    public int EnemyLayer;
    public Collider2D[] obj_check;
    int near_enemy = 0;
    public int near_enemy_save = 0;

    public float add_speed = 0.1f;
    public float check_distance = 4f;

    bool run = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        game_manager = GameObject.FindWithTag("gameManager");
        if(this.gameObject == player)
        {
            UsePassive();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (run)
        {
            obj_check = Physics2D.OverlapCircleAll(transform.position, check_distance, EnemyLayer);
            near_enemy = 0;
            if (obj_check.Length > 0)
            {
                foreach (Collider2D obj in obj_check)
                {
                    if (obj.gameObject.CompareTag("enemy"))
                    {
                        near_enemy++;
                        if(near_enemy == 10)
                        {
                            break;
                        }
                    }
                }
            }
            if(near_enemy_save != near_enemy)
            {
                game_manager.GetComponent<gameManager>().speed_applicable_figures += (near_enemy - near_enemy_save) * add_speed;
                near_enemy_save = near_enemy;
            }

        }
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

        EnemyLayer = 1 << LayerMask.NameToLayer("Enemy");
        run = true;
    }

    public void OffPassive()
    {

    }
}
