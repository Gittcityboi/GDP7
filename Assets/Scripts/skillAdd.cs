using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skillAdd : MonoBehaviour
{
    public MonoBehaviour skillScript;  // 인스펙터에 표시됨 (어떤 스크립트든 연결 가능)
    private Skill skillInterface;
    private bool applied = false;

    // Start is called before the first frame update
    void Start()
    {
        skillInterface = skillScript as Skill;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !applied)
        {
            for(int i = 0; i < other.GetComponent<playerController>().skills.Length; i++)
            {
                if(other.GetComponent<playerController>().skills[i].GetComponent<skillSlot>().skill_data == null)
                {
                    Debug.Log(i);
                    other.GetComponent<playerController>().skills[i].GetComponent<skillSlot>().skill_data = skillInterface;
                    other.GetComponent<playerController>().skills[i].GetComponent<skillSlot>().addedSkill();
                    other.GetComponent<playerController>().skillsAddingObject[i] = this.gameObject;
                    this.gameObject.SetActive(false);
                    applied = true;
                    break;
                }
            }
        }
    }
}
