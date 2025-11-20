using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skillSlot : MonoBehaviour
{
    public GameObject cooltime_img;
    public GameObject player;
    public GameObject game_manager;
    
    public Sprite skill_img;
    public Skill skill_data = null;
    public float cooltime = 0;
    public int use_count;
    public int slot_num;

    public string text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(skill_data != null)
        {
            if (cooltime > 0)
            {
                cooltime -= Time.deltaTime * game_manager.GetComponent<gameManager>().cooltime_applicable_figures;
                cooltime_img.GetComponent<Image>().fillAmount = cooltime / skill_data.cooltime;
            }
            if (cooltime < 0)
            {
                cooltime = 0;
                cooltime_img.GetComponent<Image>().fillAmount = cooltime / skill_data.cooltime;
            }
        }
        else
        {

        }
    }

    public void addedSkill()
    {
        cooltime = 0;
        cooltime_img.GetComponent<Image>().fillAmount = cooltime / skill_data.cooltime;
        use_count = skill_data.use_number;
        text = skill_data.text + "  \n남은 횟수 : " + use_count.ToString() + "  소모 마나 : " + skill_data.cost.ToString();
    }

    public void subedSkill()
    {
        cooltime = 0;
        use_count = 0;
        cooltime_img.GetComponent<Image>().fillAmount = 1;
        skill_data = null;
        Destroy(player.GetComponent<playerController>().skillsAddingObject[slot_num]);
        text = "";
    }

    public void useSkill()
    {
        if (skill_data != null)
        {
            if(cooltime <= 0 && skill_data.cost <= player.GetComponent<playerController>().mp)
            {
                skill_data.UseSkill();
                cooltime = skill_data.cooltime;
                player.GetComponent<playerController>().mp -= skill_data.cost;
                player.GetComponent<playerController>().HP_MP_UIupdate();
                if(use_count > 0)
                {
                    use_count -= 1;
                    text = skill_data.text + "  \n남은 횟수 : " + use_count.ToString() + "  소모 마나 : " + skill_data.cost.ToString();
                    if (use_count == 0)
                    {
                        subedSkill();
                    }
                }
            }
        }
    }
}
