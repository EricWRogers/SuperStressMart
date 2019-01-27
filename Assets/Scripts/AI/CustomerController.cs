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
    public float serchLeangth;
    public float audioLeangth;
    GameObject Player;
    bool end = false;
    public bool wait = false;
    bool seenPlayer = false;
    public bool gotPoint = false;
    GameObject point;
    AudioManager AudioManager;
    Animator anim;

    UnityEngine.AI.NavMeshAgent agent;

    void Start()
    {
        GameManager = (GameManager)FindObjectOfType(typeof(GameManager));
        anim = GetComponent<Animator>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        AudioManager = GameManager.GetComponent<AudioManager>();
        Player = GameObject.FindGameObjectWithTag("Player");

        MaxNumberOfIdems = Random.Range(1,10);
        targetTime = Random.Range(3,5);
        point = GameManager.RoomGOS[Random.Range(0, GameManager.RoomGOS.Length)];

        anim.SetBool("Walking", true);

        GameManager.coustomerAI += 1f;
    }

    void FixedUpdate()
    {
        if(!seenPlayer)
        {
            RaycastHit hit;

            if(!GameManager.isChasing)
            {
                if(Physics.Raycast(transform.position, Vector3.forward, out hit, serchLeangth))
                {
                    Debug.DrawRay(transform.position, Vector3.forward, Color.red);

                    if(hit.collider.tag == "Player")
                    {
                        chasingPlayer(true);
                    }
                }
            }else
            {
                if(Physics.Raycast(transform.position, Vector3.forward, out hit, audioLeangth))
                {
                    Debug.DrawRay(transform.position, Vector3.forward, Color.green);
                    if(hit.collider.tag == "Player")
                    {
                        chasingPlayer(false);
                    }
                }
            }
        }

        if(numberOfIdems < MaxNumberOfIdems)
        {
            if(point.GetComponent<WayPointManager>().available)
            {
                gotPoint = true;
            } 
            if(point.GetComponent<WayPointManager>().available == false && gotPoint == false)
            {
                point = GameManager.RoomGOS[Random.Range(0, GameManager.RoomGOS.Length)];
            }

            if(gotPoint)
            {
                point.GetComponent<WayPointManager>().available = false;
                agent.SetDestination(point.transform.position);

                float distance = Vector3.Distance(point.transform.position, transform.position);

                if(distance <= lookRadius)
                {
                    anim.SetBool("Walking", false);

                    transform.rotation = point.transform.rotation;
                    
                    anim.SetBool("Swipe", true);

                    waitTimer();

                    if(wait)
                    {
                        anim.SetBool("Swipe", false);
                        anim.SetBool("Walking", true);

                        if (this.anim.GetCurrentAnimatorStateInfo(0).IsName("Swipe"))
                        {
                            point.GetComponent<WayPointManager>().available = true;
                            point = GameManager.RoomGOS[Random.Range(0, GameManager.RoomGOS.Length)];
                            numberOfIdems++;
                            wait = false;
                            gotPoint = false;
                        }
                    }
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
                anim.SetBool("Walking", false);
                transform.rotation = point.transform.rotation;
                anim.SetBool("Swipe", true);

               waitTimer();

               if(wait)
               {
                   anim.SetBool("Swipe", false);
                   anim.SetBool("Walking", true);
                   wait = false;
                   end = true;
                   point.GetComponent<WayPointManager>().available = true;   
               }
           }
       }

       if(numberOfIdems == MaxNumberOfIdems && end)
       {
            agent.SetDestination(GameManager.exit.transform.position);

            float distance = Vector3.Distance(GameManager.exit.transform.position, transform.position);

            if(distance <= lookRadius)
            {
                Destroy(gameObject);
                GameManager.coustomerAI--;
            }
       }
    }

    void GoCheckout()
    {
        foreach(GameObject waypoint in GameManager.CheckStand)
        {
            WayPointManager RoomManager = waypoint.GetComponent<WayPointManager>();

            if ((RoomManager.RoomName == "Checkout 1" && RoomManager.available) || (RoomManager.RoomName == "Checkout 2" && RoomManager.available) || 
                (RoomManager.RoomName == "Checkout 3" && RoomManager.available) || (RoomManager.RoomName == "Checkout 4" && RoomManager.available))
            {
               point.GetComponent<WayPointManager>().available = false;    
               point = waypoint;
            }
        }
    }

    void chasingPlayer(bool holder)
    {
        GameManager.Chasing(holder);

        if(holder)
        {
            agent.SetDestination(Player.transform.position);
        }
        else
        {
            Debug.Log("PLAY");
            AudioManager.SoundsEventTrigger(SoundEvents.PathBlocked);
            GameManager.Chasing(false);
            seenPlayer = true;
        }
    }

IEnumerator GiveUp(float time)
 {
     yield return new WaitForSeconds(time);
 
     seenPlayer = false;

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
            targetTime = Random.Range(2,4);
            wait = true;
        }
    }
}
