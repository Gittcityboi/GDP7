using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shieldCreat : MonoBehaviour
{
    float max_valid_time = 10f;
    float valid_time = 10f;
    float shield_hp = 30;
    float shield_max_hp = 30;
    public GameObject game_manager;
    public GameObject shield_slider_prefab;
    GameObject shield_slider;
    // Start is called before the first frame update
    void Start()
    {
        game_manager = GameObject.FindWithTag("gameManager");
        if (this.gameObject == game_manager)
        {
            shield_max_hp = shield_hp;
            valid_time = max_valid_time;
            game_manager.GetComponent<eventManager>().OnPlayerHitEvent += OnplayerHitEvent_shield;
            shield_slider = Instantiate(shield_slider_prefab) as GameObject;
            Canvas canvas = GameObject.FindObjectOfType<Canvas>();
            shield_slider.transform.SetParent(canvas.transform, false);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject != game_manager)
        {
            return;
        }
        valid_time -= Time.deltaTime;
        if (valid_time <= 0 || shield_hp <= 0)
        {
            game_manager.GetComponent<eventManager>().OnPlayerHitEvent -= OnplayerHitEvent_shield;
            Destroy(shield_slider);
            Destroy(this);
        }
    }
    void OnplayerHitEvent_shield(GameObject player, float damage)
    {
        shield_hp -= damage;
        shield_slider.GetComponent<Slider>().value = shield_hp / shield_max_hp;
        player.GetComponent<playerController>().hp += damage;
        if(player.GetComponent<playerController>().hp > player.GetComponent<playerController>().player_max_hp)
        {
            player.GetComponent<playerController>().hp = player.GetComponent<playerController>().player_max_hp;
        }
    }

    public void reset()
    {
        shield_max_hp = shield_hp;
        valid_time = max_valid_time;
        shield_slider.GetComponent<Slider>().value = shield_hp / shield_max_hp;
    }
}
