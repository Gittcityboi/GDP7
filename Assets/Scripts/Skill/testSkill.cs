using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class testSkill : MonoBehaviour, Skill
{
    public float cooltime { get; set; } = 3f;
    public float cost { get; set; } = 3f;
    public int use_number { get; set; } = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UseSkill()
    {
        Debug.Log("testing");
    }
}
