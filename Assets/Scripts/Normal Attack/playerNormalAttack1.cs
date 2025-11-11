using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerNormalAttack1 : MonoBehaviour, normalAttack
{
    public float shoting_power = 5f;
    public float time = 0f;
    public float cooltime = 1f;

    public GameObject normal_attack1_prefab;
    public GameObject game_manager;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        game_manager = GameObject.FindWithTag("gameManager");
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(time > 0)
        {
            time -= Time.deltaTime;
        }
        else if(time < 0)
        {
            time = 0;
        }
    }
    public void UseAttack()
    {
        if(time <= 0)
        {
            time = cooltime;
            Vector3 point = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
            Vector2 point2 = new Vector2(point.x - player.transform.position.x, point.y - player.transform.position.y);
            point2 = point2.normalized;
            point2 = new Vector2(point2.x * shoting_power, point2.y * shoting_power);

            GameObject attack = Instantiate(normal_attack1_prefab, player.transform.position, Quaternion.identity) as GameObject;

            //Rigidbody2D rb = attack.GetComponent<Rigidbody2D>();
            //rb.velocity = point2;
            attack.GetComponent<Rigidbody2D>().AddForce(point2, ForceMode2D.Impulse);
        }
    }

}
