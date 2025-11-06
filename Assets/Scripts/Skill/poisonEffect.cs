using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poisonEffect : MonoBehaviour
{
    float valid_time = 10;
    float damage = 3f; 
    float damage_cycle = 1f; 
    public float time = 0f;
    // Start is called before the first frame update
    void Start()
    {
        if (this.gameObject.CompareTag("enemy"))
        {
            StartCoroutine(effect());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator effect()
    {
        
        while (time < valid_time)
        {
            if (this.gameObject == null) yield break;

            this.gameObject.GetComponent<enemyScript>()?.damaged(damage);

            yield return new WaitForSeconds(damage_cycle);
            time += damage_cycle;
        }
        Destroy(this);
    }
}
