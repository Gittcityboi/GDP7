using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour
{
    public GameObject game_manager;
    public GameObject[] skills = new GameObject[5];
    public GameObject[] skillsAddingObject = new GameObject[5];
    public float player_speed = 1f;
    public float skill_change_count = 0;
    public float skill_change_max_count = 20;
    public int choiced_skill = 0;
    int choiced_skill_change = 1;
    public float max_wheel_time = 3;
    public float wheel_time = 0;

    public float normal_max_hp = 100;
    public float player_max_hp = 100;
    public float hp = 100;
    public float normal_max_mp = 100;
    public float player_max_mp = 100;
    public float mp = 100;
    public GameObject hp_bar;
    public GameObject mp_bar;

    public float invincibility_hit_time = 1f;
    public float hit_time = 0f;

    public bool invincibility = false;
    public bool stop = false;
    public float roll_power = 300f;
    public float roll_time = 0f;
    public float roll_cooltime = 4f;

    public normalAttack normal_attack_data = null;
    public MonoBehaviour normal_attack_script = null;

    // Start is called before the first frame update
    void Start()
    {
        normal_max_hp = hp;
        normal_max_mp = mp;
        if(normal_attack_script != null)
        {
            changeNormalAttack(normal_attack_script);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 move_vector = new Vector2(0, 0);
        if (Input.GetKey(KeyCode.W) && !stop)
        {
            move_vector.y += 1;
        }
        if (Input.GetKey(KeyCode.S) && !stop)
        {
            move_vector.y -= 1;
        }
        if (Input.GetKey(KeyCode.A) && !stop)
        {
            move_vector.x -= 1;
        }
        if (Input.GetKey(KeyCode.D) && !stop)
        {
            move_vector.x += 1;
        }
        move_vector = move_vector.normalized;
        transform.Translate(move_vector * player_speed * game_manager.GetComponent<gameManager>().speed_applicable_figures);

        if (Input.GetKeyDown(KeyCode.Space) && roll_time == 0)
        {
            Vector3 point = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y, -Camera.main.transform.position.z));
            //Debug.Log(point);
            Vector2 point2 = new Vector2(point.x - this.gameObject.transform.position.x, point.y - this.gameObject.transform.position.y);
            point2 = point2.normalized;
            point2 = new Vector2(point2.x * roll_power,point2.y * roll_power);
            //move_vector = new Vector2(0, 0);
            roll_time = roll_cooltime;
            StartCoroutine(roll(point2));
        }
        if(roll_time > 0)
        {
            roll_time -= Time.deltaTime;
        }
        else if(roll_time < 0)
        {
            roll_time = 0;
        }

        float wheel_input = Input.GetAxis("Mouse ScrollWheel");
        bool wheel_time_limit = false;
        if (wheel_input > 0 && skill_change_count < skill_change_max_count)
        {
            if (skill_change_count < skill_change_max_count)
            {
                skill_change_count += 1;
            }
        }
        else if (wheel_input < 0 && skill_change_count > -skill_change_max_count)
        {
            skill_change_count -= 1;
        }
        else
        {
            wheel_time_limit = true;
        }
        
        if (wheel_time_limit)
        {
            wheel_time -= Time.deltaTime;
            if(wheel_time < 0)
            {
                wheel_time = 0;
            }
        }
        else
        {
            wheel_time = max_wheel_time;
        }
        if(wheel_time == 0)
        {
            skill_change_count = 0;
        }

        if(skill_change_max_count <= skill_change_count)
        {
            skill_change_count = 0;
            choiced_skill -= 1;
            if (choiced_skill == -1)
            {
                choiced_skill = 4;
            }
        }
        if (skill_change_max_count <= -1 * skill_change_count)
        {
            skill_change_count = 0;
            choiced_skill += 1;
            if(choiced_skill == 5)
            {
                choiced_skill = 0;
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            if(normal_attack_data != null)
            {
                normal_attack_data.UseAttack();
            }
            //Debug.Log(choiced_skill);
        }
        
        if (Input.GetMouseButtonDown(1))
        {
            if(skills[choiced_skill].GetComponent<skillSlot>().skill_data != null)
            {
                skills[choiced_skill].GetComponent<skillSlot>().useSkill();
            }
            //Debug.Log(choiced_skill);
        }
        if (Input.GetKey(KeyCode.Alpha1))
        {
            choiced_skill = 0;
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            choiced_skill = 1;
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            choiced_skill = 2;
        }
        if (Input.GetKey(KeyCode.Alpha4))
        {
            choiced_skill = 3;
        }
        if (Input.GetKey(KeyCode.Alpha5))
        {
            choiced_skill = 4;
        }

        if(choiced_skill_change != choiced_skill)
        {
            for (int i = 0; i < skills.Length; i++)
            {
                if(skills[i] != null)
                {
                    if(i == choiced_skill)
                    {
                        skills[i].GetComponent<skillCardUpDown>().choiced = true;
                    }
                    else
                    {
                        skills[i].GetComponent<skillCardUpDown>().choiced = false;
                    }
                }
            }
        }
        choiced_skill_change = choiced_skill;

        if (Input.GetKeyDown(KeyCode.E) && game_manager.GetComponent<gameManager>().time_distortion_system != 1)
        {
            game_manager.GetComponent<gameManager>().time_distortion_system += 1;
            game_manager.GetComponent<gameManager>().timeDistortionSystem(1);
        }
        if (Input.GetKeyDown(KeyCode.Q) && game_manager.GetComponent<gameManager>().time_distortion_system != -1)
        {
            game_manager.GetComponent<gameManager>().time_distortion_system -= 1;
            game_manager.GetComponent<gameManager>().timeDistortionSystem(-1);
        }

        if (hit_time > 0f)
        {
            hit_time -= Time.deltaTime;
        }
        else if (hit_time < 0f)
        {
            hit_time = 0f;
        }
    }

    public void changeNormalAttack(MonoBehaviour normalAttackScript)
    {
        normal_attack_data = normalAttackScript as normalAttack;
    }

    public void HP_MP_UIupdate()
    {
        hp_bar.GetComponent<Slider>().value = hp / player_max_hp;
        mp_bar.GetComponent<Slider>().value = mp / player_max_mp;
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy") && hit_time <= 0 && !invincibility)
        {
            hit_time = invincibility_hit_time;
            if (hp <= 0)
            {
                //Debug.Log("dead");
                return;
            }
            hp -= collision.gameObject.GetComponent<enemyScript>().damage;
            //Debug.Log("player hit");
            HP_MP_UIupdate();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("exp"))
        {
            //Debug.Log("exp");
            game_manager.GetComponent<levelManager>().gainExp(other.GetComponent<experience>().exp);
        }
    }

    private IEnumerator roll(Vector2 point2)
    {
        stop = true;
        invincibility = true;
        this.gameObject.GetComponent<Collider2D>().isTrigger = true;
        this.gameObject.GetComponent<Rigidbody2D>().AddForce(point2, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.6f);
        stop = false;
        invincibility = false;
        yield return new WaitForSeconds(0.1f);
        this.gameObject.GetComponent<Collider2D>().isTrigger = false;
    }
}
