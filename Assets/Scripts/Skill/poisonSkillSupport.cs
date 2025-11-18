using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poisonSkillSupport : MonoBehaviour
{
    public GameObject game_manager;
    float valid_time = 10f;
    public MonoBehaviour poisonEffect;

    // Start is called before the first frame update
    void Start()
    {
        game_manager = GameObject.FindWithTag("gameManager");
        if (this.gameObject == game_manager)
        {
            StartCoroutine(counting());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator counting()
    {
        game_manager.GetComponent<eventManager>().OnEnemyHitEvent += OnEnemyHitEvent_poison;
        yield return new WaitForSeconds(valid_time);
        game_manager.GetComponent<eventManager>().OnEnemyHitEvent -= OnEnemyHitEvent_poison;
        Destroy(this);
    }

    void OnEnemyHitEvent_poison(GameObject other, float damage)
    {
        if (other.GetComponent(poisonEffect.GetType()) == null)
        {
            other.AddComponent(poisonEffect.GetType());
        }
        else
        {
            other.GetComponent<poisonEffect>().time = 0f;
        }
    }
}
