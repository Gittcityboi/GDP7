using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dashSkill : MonoBehaviour, Skill
{

    public float cooltime { get; set; } = 3f;
    public float cost { get; set; } = 3f;
    public int use_number { get; set; } = 3;

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
