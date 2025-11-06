using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelManager : MonoBehaviour
{
    public int level = 1;
    public float max_exp = 100;
    public float player_exp = 0;
    public GameObject exp_bar;

    // Start is called before the first frame update
    void Start()
    {
        gainExp(0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void gainExp(float amount)
    {
        player_exp += amount;
        exp_bar.GetComponent<Slider>().value = player_exp / max_exp;

        if(player_exp / max_exp > 1)
        {
            player_exp -= max_exp;
            level++;
            levelReward();
        }
    }

    public void levelReward()
    {
        exp_bar.GetComponent<Slider>().value = player_exp / max_exp;
    }
}
