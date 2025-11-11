using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerNormalAttack1Support : MonoBehaviour
{
    float valid_time = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        valid_time -= Time.deltaTime;
        if(valid_time <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
