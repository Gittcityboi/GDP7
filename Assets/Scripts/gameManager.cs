using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public float acceleration = 0.3f;
    public float deceleration = -0.3f;

    public GameObject[] TDS_ui = new GameObject[3];

    //public float speed_proportion = 1.0f;
    public float speed_applicable_figures = 1.0f;
    public float cooltime_applicable_figures = 1.0f;

    public int time_distortion_system = 0;

    public GameObject player;

    public float mp_recover = 1;
    public float mp_cost = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(time_distortion_system > 0)
        {
            player.GetComponent<playerController>().mp -= mp_cost * 0.01f;
            player.GetComponent<playerController>().HP_MP_UIupdate();
            if (player.GetComponent<playerController>().mp <= 0)
            {
                player.GetComponent<playerController>().mp = 0;
                time_distortion_system -= 1;
                timeDistortionSystem(-1);
            }
        }
        else if(time_distortion_system < 0)
        {
            player.GetComponent<playerController>().mp += mp_recover * 0.01f;
            player.GetComponent<playerController>().HP_MP_UIupdate();
            if(player.GetComponent<playerController>().mp > player.GetComponent<playerController>().player_max_mp)
            {
                player.GetComponent<playerController>().mp = player.GetComponent<playerController>().player_max_mp;
            }
        }
    }

    public void timeDistortionSystem(int delta)
    {
        if(delta == 1)
        {
            if(time_distortion_system > 0)
            {
                accelerationSystemOn();
            }
            else
            {
                decelerationSystemOff();
            }
        }
        if (delta == -1)
        {
            if (time_distortion_system < 0)
            {
                decelerationSystemOn();
            }
            else
            {
                accelerationSystemOff();
            }
        }
        for(int i = 0; i < TDS_ui.Length; i++)
        {
            if(i == time_distortion_system + 1)
            {
                TDS_ui[i].SetActive(true);
            }
            else
            {
                TDS_ui[i].SetActive(false);
            }
        }
    }

    public void accelerationSystemOn()
    {
        speed_applicable_figures += acceleration;
        cooltime_applicable_figures += acceleration;
    }
    public void accelerationSystemOff()
    {
        speed_applicable_figures -= acceleration;
        cooltime_applicable_figures -= acceleration;
    }
    public void decelerationSystemOn()
    {
        speed_applicable_figures += deceleration;
        cooltime_applicable_figures += deceleration;
    }
    public void decelerationSystemOff()
    {
        speed_applicable_figures -= deceleration;
        cooltime_applicable_figures -= deceleration;
    }

}
