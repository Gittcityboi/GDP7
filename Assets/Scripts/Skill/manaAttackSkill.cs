using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manaAttackSkill : MonoBehaviour, Skill
{
    public float cooltime { get; set; } = 3f;
    public float cost { get; set; } = 1f;
    public int use_number { get; set; } = 3;
    public float shoting_power = 5;
    public GameObject manaAttack_prefab; 
    public string text { get; set; } = "마나 공격 - 마나를 최대 50소모하여 소모한 마나에 비례해 피해량이 증가합니다";
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UseSkill()
    {
        Vector3 point = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
        Vector2 point2 = new Vector2(point.x - player.transform.position.x, point.y - player.transform.position.y);
        point2 = point2.normalized;
        point2 = new Vector2(point2.x * shoting_power, point2.y * shoting_power);

        GameObject attack = Instantiate(manaAttack_prefab, player.transform.position, Quaternion.identity) as GameObject;

        if(player.GetComponent<playerController>().mp < 49)
        {
            attack.GetComponent<playerAttack>().damage += player.GetComponent<playerController>().mp;
            player.GetComponent<playerController>().mp = 0;
        }
        else
        {
            attack.GetComponent<playerAttack>().damage += 49;
            player.GetComponent<playerController>().mp -= 49;

        }

        attack.GetComponent<Rigidbody2D>().AddForce(point2, ForceMode2D.Impulse);
    }
}
