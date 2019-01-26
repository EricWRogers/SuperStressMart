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
    GameObject point;
    Animator anim;

    UnityEngine.AI.NavMeshAgent agent;

    void Start()
    {
        GameManager = (GameManager)FindObjectOfType(typeof(GameManager));
        anim = GetComponent<Animator>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        MaxNumberOfIdems = Random.Range(1,4);
        targetTime = Random.Range(3,5);
        point = GameManager.RoomGOS[Random.Range(0, GameManager.RoomGOS.Length)];

        anim.SetBool("Walking", true);

        GameManager.AICount++;
    }

    void FixedUpdate()
    {
        if(numberOfIdems < MaxNumberOfIdems)
        {
            agent.SetDestination(point.transform.position);

            float distance = Vector3.Distance(point.transform.position, transform.position);

            if(distance <= lookRadius)
            {
                anim.SetBool("Walking", false);
                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + point.GetComponent<WayPointManager>().turn, transform.rotation.eulerAngles.z);
                anim.SetBool("Swipe", true);
                waitTimer();

                if (this.anim.GetCurrentAnimatorStateInfo(0).IsName("Swipe") && wait)
                {
                    anim.SetBool("Swipe", false);
                    anim.SetBool("Walking", true);
                    point = GameManager.RoomGOS[Random.Range(0, GameManager.RoomGOS.Length)];
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

            if (RoomManager.RoomName == "Checkout 1")
            {   
               point = waypoint;
            }
        }
    }
    
    void FaceTarget()
    {
        Vector3 distance = (point.transform.position - transform.position).normalized;
        Quaternion lookRatation = Quaternion.LookRotation(new Vector3(distance.x, 0, distance.z));
        transform.rotation = Quaternion.Slerp(point.transform.rotation, lookRatation, Time.deltaTime * 5f);
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
