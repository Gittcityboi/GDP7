using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skillCardUpDown : MonoBehaviour
{
    public bool choiced = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(choiced)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, 20f, 0), 0.05f);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, -100f, 0), 0.05f);
        }
        
    }
}
