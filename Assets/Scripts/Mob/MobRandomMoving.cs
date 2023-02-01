using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MobRandomMoving : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent agent;

    [SerializeField]
    private Transform floor;
    [SerializeField]
    private Animator animator;

    private float move_x_pos;
    private float move_z_pos;
    [SerializeField]
    private float random_factor = 5f;

    Vector3 destination;
    float timer;
    int waitingTime;

    private void Start()
    {
        timer = 0.0f;
        waitingTime = 5;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        destination = transform.position;
    }
    
    private void Update()
    {
        

            //목적지에 도착	
            if ((transform.position - destination).magnitude < 0.1f)
            {
                timer += Time.deltaTime;

                animator.SetBool("IsWalking", false);
                move_x_pos = Random.Range(-random_factor, random_factor);
                move_z_pos = Random.Range(-random_factor, random_factor);


                //목적지를 갱신
                if(timer > waitingTime)
                {
                    destination = new Vector3(move_x_pos, 0, move_z_pos);
                    agent.SetDestination(destination);
                    animator.SetBool("IsWalking", true);
                    timer = 0;
                }
            }
    }




}
