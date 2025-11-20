using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoAttack1Passive : MonoBehaviour
{
    public GameObject player;
    public GameObject autoAttack1_prefab;

    float cool_time = 5;

    public Vector2 dir;
    public float distance;

    public Collider2D[] obj_check;
    public float max_distance = 20f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        if (this.gameObject == player)
        {
            UsePassive();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void AddPassive()
    {
        if (player.GetComponent(this.GetType()) == null)
        {
            //game_manager.AddComponent(this.GetType());
            var support = player.AddComponent(this.GetType()) as autoAttack1Passive;
            support.autoAttack1_prefab = GetComponent<autoAttack1Passive>().autoAttack1_prefab;
        }
    }

    public void UsePassive()
    {
        StartCoroutine(autoATtack());
    }

    public void OffPassive()
    {

    }

    void OnPlayerHitEvent_reflection(GameObject other, float damage)
    {

    }

    private IEnumerator autoATtack()
    {
        int EnemyLayer = 1 << LayerMask.NameToLayer("Enemy");
        int WallLayer = 1 << LayerMask.NameToLayer("Wall");

        obj_check = Physics2D.OverlapCircleAll(transform.position, 10, EnemyLayer);
        float min_distance = 1000;
        dir = new Vector2 (0,0);
        if (obj_check.Length > 0)
        {
            foreach (Collider2D obj in obj_check)
            {
                if (obj.gameObject.CompareTag("enemy") && min_distance > Vector3.Distance(obj.gameObject.transform.position,player.transform.position))
                {
                    min_distance = Vector3.Distance(obj.gameObject.transform.position, player.transform.position);
                    dir = new Vector2(obj.gameObject.transform.position.x - player.transform.position.x, obj.gameObject.transform.position.y - player.transform.position.y);
                    dir.Normalize();
                }
            }
        }
        if(min_distance != 1000)
        {
            //Debug.Log(dir);
            RaycastHit2D hit = Physics2D.Raycast(player.transform.position, dir, max_distance, WallLayer);
            distance = (hit.collider != null) ? hit.distance : max_distance;
            //Debug.Log(distance);
            GameObject attack = Instantiate(autoAttack1_prefab, player.transform.position, Quaternion.identity) as GameObject;

            Vector3 centerPos = player.transform.position + (Vector3)dir * (distance * 0.5f);
            attack.transform.position = new Vector3(centerPos.x, centerPos.y,1);

            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            attack.transform.rotation = Quaternion.Euler(0f, 0f, angle);

            attack.transform.localScale = new Vector3(distance, 0.2f, 1f);
        }
        //Debug.Log(min_distance);
        yield return new WaitForSeconds(cool_time);
        StartCoroutine(autoATtack());
    }
}
