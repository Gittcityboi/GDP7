using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shieldSkill : MonoBehaviour,Skill
{
    public float cooltime { get; set; } = 3f;
    public float cost { get; set; } = 3f;
    public int use_number { get; set; } = 3;
    public GameObject game_manager;
    public GameObject shield_slider_prefab;
    public MonoBehaviour shieldCreat;
    // Start is called before the first frame update
    void Start()
    {
        game_manager = GameObject.FindWithTag("gameManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UseSkill()
    {
        var existing = game_manager.GetComponent<shieldCreat>();
        if (existing == null)
        {
            var support = game_manager.AddComponent(shieldCreat.GetType()) as shieldCreat;
            support.shield_slider_prefab = shield_slider_prefab;
        }
        else
        {
            game_manager.GetComponent<shieldCreat>().reset();
        }
    }
}
