using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor.AI;

public class CustomerController : MonoBehaviour
{
    public float lookRadius = 3f;
    public GameManager GameManager;
    Transform point;
    UnityEngine.AI.NavMeshAgent agent;

    void Start()
    {
        GameManager = (GameManager)FindObjectOfType(typeof(GameManager));
        point = GameManager.RoomGOS[Random.Range(0, GameManager.RoomGOS.Length)].transform;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    void Update()
    {
        float distance = Vector3.Distance(point.position, transform.position);

        agent.SetDestination(point.position);

         if(distance <= lookRadius)
        {
            agent.SetDestination(point.position);
            point = GameManager.RoomGOS[Random.Range(0, GameManager.RoomGOS.Length)].transform;

            if(distance <= agent.stoppingDistance)
            {

            }
       }
    }

    void FaceTarget()
    {
        Vector3 distance = (point.position - transform.position).normalized;
        Quaternion lookRatation = Quaternion.LookRotation(new Vector3(distance.x, 0, distance.z));
        transform.rotation = Quaternion.Slerp(point.rotation, lookRatation, Time.deltaTime * 5f);
    }

     void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, lookRadius);
    }
}
