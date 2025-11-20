using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoAttack1PassiveSupport : MonoBehaviour
{
    public GameObject player;
    float valid_time = 0.4f;
    Vector3 dir;
    float distance;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        dir = player.GetComponent<autoAttack1Passive>().dir;
        distance = player.GetComponent<autoAttack1Passive>().distance;
        StartCoroutine(destroy());
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 centerPos = player.transform.position + (Vector3)dir * (distance * 0.5f);
        this.transform.position = new Vector3(centerPos.x, centerPos.y, 1);
    }
    private IEnumerator destroy()
    {
        yield return new WaitForSeconds(valid_time);
        Destroy(this.gameObject);
    }
}
