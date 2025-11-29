using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombAttack : MonoBehaviour
{
    float valid_time = 3f;
    public GameObject bomb;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        valid_time -= Time.deltaTime;
        if (valid_time <= 0)
        {
            if(this.gameObject.GetComponent<BoxCollider2D>().enabled == false)
            {
                this.gameObject.transform.localScale = new Vector3(2f, 2f, 2f);
                this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
                valid_time = 0.1f;
                bomb.SetActive(true);
                
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }
}
