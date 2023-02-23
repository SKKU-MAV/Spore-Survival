using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MobHit: MonoBehaviour
{
    [SerializeField]
    float hitPoints = 100f;

    [SerializeField]
    GameObject dropitem;

    [SerializeField]
    float dieingTime = 1.5f;

    MobRandomMoving mobRandomMoving;
    NavMeshAgent agent;
    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        mobRandomMoving = GetComponent<MobRandomMoving>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        StartCoroutine(Damaged(20f));
    }

    public IEnumerator Damaged(float damage)
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            hitPoints -= damage;
            anim.Play("GetHit");

            if (hitPoints <= 0)
            {
                mobRandomMoving.enabled = false;
                agent.enabled = false;
                
                anim.Play("Die");
                yield return new WaitForSeconds(dieingTime);
                Destroy(gameObject);
                Instantiate(dropitem, transform.position, transform.rotation);
            }
        }
        
    }

    

}
