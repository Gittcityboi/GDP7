using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reflectionDamagePassiveSupport : MonoBehaviour
{
    float valid_time = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(destroy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator destroy()
    {
        yield return new WaitForSeconds(valid_time);
        Destroy(this.gameObject);
    }
}
