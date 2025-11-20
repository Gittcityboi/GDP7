using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dashSkill : MonoBehaviour, Skill
{

    public float cooltime { get; set; } = 3f;
    public float cost { get; set; } = 3f;
    public int use_number { get; set; } = 3;
    public string text { get; set; } = "돌진 - 마우스의 방향으로 돌진하여 충돌한 적에게 피해를 입힙니다";
    public GameObject player;
    public GameObject dash_attack_prefab;

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
        GameObject dash = Instantiate(dash_attack_prefab, player.transform) as GameObject;
        //dash.transform.SetParent(player.transform, false);
    }

    
}
