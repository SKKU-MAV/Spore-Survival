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
    private Animator object;

    private float move_x_pos;
    private float move_z_pos;
    [SerializeField]
    private float random_factor = 5f;

    Vector3 destination;
    float timer;
    int waitingTime;

    private void Awake()
    {
        timer = 0.0f;
        waitingTime = 2;
        agent = GetComponent<NavMeshAgent>();
        object = GetComponent<Animator>();
        destination = transform.position;
    }
    
    private void Update()
    {
        timer += Time.deltaTime;
   
        if(timer > waitingTime)
        {
            if ((transform.position - destination).magnitude < 0.1f)
            {
            object.
            move_x_pos = Random.Range(-random_factor, random_factor);
            move_z_pos = Random.Range(-random_factor, random_factor);
            destination = new Vector3(move_x_pos, 0, move_z_pos);



            agent.SetDestination(destination);
            }

            timer = 0;
        }
    }




}
