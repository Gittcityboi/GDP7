using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dashAttack : MonoBehaviour
{
    public GameObject player;
    public float power = 30f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        if(player != this.gameObject.transform.parent.gameObject)
        {
            return;
        }
        Vector3 point = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
        Vector2 point2 = new Vector2(point.x - player.transform.position.x, point.y - player.transform.position.y);
        point2 = point2.normalized;
        point2 = new Vector2(point2.x * power, point2.y * power);
        StartCoroutine(dashAttaack(point2));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator dashAttaack(Vector2 point2)
    {
        player.GetComponent<playerController>().stop = true;
        player.GetComponent<playerController>().invincibility = true;
        player.GetComponent<Rigidbody2D>().AddForce(point2, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.8f);
        player.GetComponent<playerController>().stop = false;
        player.GetComponent<playerController>().invincibility = false;
        Destroy(this.gameObject);
    }
}
