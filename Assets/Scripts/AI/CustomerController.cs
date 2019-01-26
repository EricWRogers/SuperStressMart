using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.AI;

public class CustomerController : MonoBehaviour
{
    public float lookRadius = 10f;

    GameObject player;
    UnityEngine.AI.NavMeshAgent agent;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);

        if(distance <= lookRadius)
        {
            agent.SetDestination(player.transform.position);

            if(distance <= agent.stoppingDistance)
            {
                FaceTarget();
            }
        }
    }

    void FaceTarget()
    {
        Vector3 distance = (player.transform.position - transform.position).normalized;
        Quaternion lookRatation = Quaternion.LookRotation(new Vector3(distance.x, 0, distance.z));
        transform.rotation = Quaternion.Slerp(player.transform.rotation, lookRatation, Time.deltaTime * 5f);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, lookRadius);
    }
}
