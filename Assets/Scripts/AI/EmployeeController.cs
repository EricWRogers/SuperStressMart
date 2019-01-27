using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmployeeController : MonoBehaviour
{
    public float lookRadius = 3f;
    private float rayLength = 3f;

    public string workArea = "";
    public float serchLeangth;
    public float audioLeangth;
    public float numberOfIdems = 0.0f;
    public float MaxNumberOfIdems;
    public float giveupTime;
    GameManager GameManager;
    AudioManager AudioManager;
    GameObject point;
    GameObject Player;
    float targetTime;
    bool end = false;
    bool wait = false;
    bool giveup = false;
    bool seenPlayer = false;
    bool gotPoint = false;
    bool Audioplayed = false;
    int  index = 0;
    Animator anim;
    UnityEngine.AI.NavMeshAgent agent;

    void Start()
    {
        GameManager = (GameManager)FindObjectOfType(typeof(GameManager));
        AudioManager = GameManager.GetComponent<AudioManager>();
        GameObject dfkasjdf = GameManager.RoomGOS[index];
        anim = GetComponent<Animator>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        Player = GameObject.FindGameObjectWithTag("Player");
        MaxNumberOfIdems = Random.Range(1,4);
        targetTime = Random.Range(3,5);
        FindNextPoint();
        point = GameManager.RoomGOS[index];
    }

    void FixedUpdate()
    {
        if(point.GetComponent<WayPointManager>().available)
        {
            gotPoint = true;
        } 
        if(point.GetComponent<WayPointManager>().available == false && gotPoint == false)
        {
            FindNextPoint();
            point = GameManager.RoomGOS[index];
        }

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

        if(gotPoint)
        {
            point.GetComponent<WayPointManager>().available = false;

            agent.SetDestination(point.transform.position);

            anim.SetBool("Walking", true);

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
                        FindNextPoint();
                        point = GameManager.RoomGOS[index];
                        numberOfIdems++;
                        wait = false;
                        gotPoint = false;
                    
                    }
                }
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
            AudioManager.SoundsEventTrigger(SoundEvents.PathBlocked);
            GameManager.ChangeStress(0.1f);
            GameManager.Chasing(false);
            seenPlayer = true;
        }
    }

    void FindNextPoint()
    {
        bool nextpoint = true;
        if(GameManager.RoomGOS.Length > 0 || workArea != "")
        {
            Debug.Log(GameManager.RoomGOS[index].GetComponent<WayPointManager>().RoomName);
            while(nextpoint)
            {
                index++;
                if(index == GameManager.RoomGOS.Length)
                {
                    index = 0;
                }
                if(GameManager.RoomGOS[index].GetComponent<WayPointManager>().RoomName == workArea)
                {
                    nextpoint = false;
                }
            }
        }
    }

    IEnumerator GiveUp(float time)
 {
     yield return new WaitForSeconds(time);
 
     seenPlayer = false;

 }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(transform.position, lookRadius);
    }

    void waitTimer()
    {
        targetTime -= Time.deltaTime;
        
        if (targetTime <= 0.0f)
        {
            targetTime = Random.Range(2,3);
            wait = true;
        }
    }
}
