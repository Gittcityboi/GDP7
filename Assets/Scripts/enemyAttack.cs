using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAttack : MonoBehaviour
{
    public float damage = 5f;
    public int hit_count = -1;
    public bool wall = false;
    public float valid_time = -1f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(valid_time > 0)
        {
            valid_time -= Time.deltaTime;
            if (valid_time <= 0)
            {
                valid_time = 0;
            }
        }
        if (valid_time == 0)
        {
            Destroy(this.gameObject);
        }
    }
    void LateUpdate()
    {
        if (hit_count == 0 && valid_time > 0.1) 
        {
            valid_time = 0.1f;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && hit_count > 0)
        {
            hit_count--;
            
        }
        if (other.CompareTag("wall") && wall)
        {
            Destroy(this.gameObject);
        }
    }
}
