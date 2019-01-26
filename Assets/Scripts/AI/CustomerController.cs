using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor.AI;

public class CustomerController : MonoBehaviour
{
    public float lookRadius = 3f;
    public float numberOfIdems = 0.0f;
    public float MaxNumberOfIdems;
    public float targetTime;
    GameManager GameManager;
    bool end = false;
    private bool wait = false;
    Transform point;
    Animator anim;

    UnityEngine.AI.NavMeshAgent agent;

    void Start()
    {
        GameManager = (GameManager)FindObjectOfType(typeof(GameManager));
        point = GameManager.RoomGOS[Random.Range(0, GameManager.RoomGOS.Length)].transform;
        anim = GetComponent<Animator>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        MaxNumberOfIdems = Random.Range(1,4);
        GameManager.AICount++;
        targetTime = Random.Range(3,5);
        anim.SetBool("Walking", true);
    }

    void FixedUpdate()
    {
        if(numberOfIdems < MaxNumberOfIdems)
        {
            agent.SetDestination(point.position);

            float distance = Vector3.Distance(point.transform.position, transform.position);

            if(distance <= lookRadius)
            {
                anim.SetBool("Walking", false);
                waitTimer();

                if (this.anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") && wait)
                {
                    anim.SetBool("Walking", true);
                    point = GameManager.RoomGOS[Random.Range(0, GameManager.RoomGOS.Length)].transform;
                    agent.SetDestination(point.position);
                    numberOfIdems++;
                    wait = false;
                }
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

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, lookRadius);
    }

    void waitTimer()
    {
        targetTime -= Time.deltaTime;
        
        if (targetTime <= 0.0f)
        {
            targetTime = Random.Range(3,5);
            wait = true;
        }
    }
}
