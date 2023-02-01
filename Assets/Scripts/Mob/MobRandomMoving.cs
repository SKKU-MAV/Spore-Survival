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

    private float move_x_pos;
    private float move_z_pos;
    [SerializeField]
    private float random_factor = 5f;

    Vector3 destination;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        destination = transform.position;
    }
    
    private void Update()
    {
        Debug.Log($"Dest : {destination}");
        Debug.Log($"Pos: {transform.position}");

        if ((transform.position - destination).magnitude < 0.1f)
        {
            Debug.Log(destination);
            move_x_pos = Random.Range(-random_factor, random_factor);
            move_z_pos = Random.Range(-random_factor, random_factor);
            destination = new Vector3(move_x_pos, 0, move_z_pos);

            Waiting(Random.Range(2f, 3f));
            agent.SetDestination(destination);


        }



    }

    private void Waiting(float waitingTime)
    {
        float startTime = Time.time;

        while (true)
        {
            if (Time.time - startTime >= waitingTime)
                return;
        }
    }



}
