using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poisonSkill : MonoBehaviour, Skill
{
    public GameObject game_manager;
    public MonoBehaviour poisonEffectAddSub;
    public MonoBehaviour poisonEffect;

    public float cooltime { get; set; } = 3f;
    public float cost { get; set; } = 3f;
    public int use_number { get; set; } = 3;
    // Start is called before the first frame update
    void Start()
    {
        game_manager = GameObject.FindWithTag("gameManager");
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void UseSkill()
    {
        //game_manager.GetComponent<eventManager>().OnEnemyHitEvent += OnEnemyHitEvent_poison;
        //Debug.Log("testing");
        if (game_manager.GetComponent(poisonEffectAddSub.GetType()) == null)
        {
            //game_manager.AddComponent(poisonEffectAddSub.GetType());
            var support = game_manager.AddComponent(poisonEffectAddSub.GetType()) as poisonSkillSupport;
            support.poisonEffect = GetComponent<poisonSkillSupport>().poisonEffect;
        }
    }
    /*
    void OnEnemyHitEvent_poison(GameObject other)
    {
        if (other.GetComponent(poisonEffect.GetType()) == null)
        {
            other.AddComponent(poisonEffect.GetType());
        }
    }
    */
}
