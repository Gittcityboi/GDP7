using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour
{
    public float damage = 10f;
    public float hit_time = 1f;
    public int hit_count = -1;
    public bool wall = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("enemy") && hit_count > 0)
        { 
            hit_count--;
            if(hit_count == 0)
            {
                Destroy(this.gameObject);
            }
        }
        if (other.CompareTag("wall") && wall)
        {
            Destroy(this.gameObject);
        }
    }
}
