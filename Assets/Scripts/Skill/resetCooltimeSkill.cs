using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetCooltimeSkill : MonoBehaviour,Skill
{
    public float cooltime { get; set; } = 3f;
    public float cost { get; set; } = 3f;
    public int use_number { get; set; } = 3;
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
        for (int i = 0; i < player.GetComponent<playerController>().skills.Length; i++)
        {
            if (player.GetComponent<playerController>().skills[i].GetComponent<skillSlot>().skill_data != null)
            {
                if (player.GetComponent<playerController>().skills[i].GetComponent<skillSlot>().skill_data == this as Skill)
                {
                    continue;
                }
                player.GetComponent<playerController>().skills[i].GetComponent<skillSlot>().cooltime = -0.01f;
            }
        }
    }
}
