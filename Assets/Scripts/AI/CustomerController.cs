using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor.AI;

public class CustomerController : MonoBehaviour
{
    public float lookRadius = 3f;
    private GameManager GameManager;
    public float numberOfIdems = 0.0f;
    public float MaxNumberOfIdems;
    public bool end = false;
    Transform point;

    UnityEngine.AI.NavMeshAgent agent;

    void Start()
    {
        GameManager = (GameManager)FindObjectOfType(typeof(GameManager));
        point = GameManager.RoomGOS[Random.Range(0, GameManager.RoomGOS.Length)].transform;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        MaxNumberOfIdems = Random.Range(1,4);
        GameManager.AICount++;
    }

    void FixedUpdate()
    {
        if(numberOfIdems < MaxNumberOfIdems)
        {
            agent.SetDestination(point.position);

            float distance = Vector3.Distance(point.transform.position, transform.position);

            if(distance <= lookRadius)
            {
                point = GameManager.RoomGOS[Random.Range(0, GameManager.RoomGOS.Length)].transform;
                agent.SetDestination(point.position);
                numberOfIdems++;
            }
        }

       if(numberOfIdems == MaxNumberOfIdems && !end)
       {
           GoCheckout();

           agent.SetDestination(point.transform.position);

           float distance = Vector3.Distance(point.transform.position, transform.position);

           if (distance <= lookRadius)
           {
               end = true;
           }
       }

       if(numberOfIdems == MaxNumberOfIdems && end)
       {
            agent.SetDestination(GameManager.exit.transform.position);

            float distance = Vector3.Distance(GameManager.exit.transform.position, transform.position);

            if(distance <= lookRadius)
            {
                Destroy(gameObject);
                GameManager.AICount--;
            }
       }
    }

    void GoCheckout()
    {
        foreach(GameObject waypoint in GameManager.CheckStand)
        {
            WayPointManager RoomManager = waypoint.GetComponent<WayPointManager>();

            if ( RoomManager.RoomName == "Checkout 1")
            {   
               point = waypoint.transform;
            }
        }
    }
    
    void FaceTarget()
    {
        Vector3 distance = (point.position - transform.position).normalized;
        Quaternion lookRatation = Quaternion.LookRotation(new Vector3(distance.x, 0, distance.z));
        transform.rotation = Quaternion.Slerp(point.rotation, lookRatation, Time.deltaTime * 5f);
    }

     /* void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, lookRadius);
    } */
}
