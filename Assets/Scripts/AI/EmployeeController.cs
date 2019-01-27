using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmployeeController : MonoBehaviour
{
    public float lookRadius = 3f;
    public float numberOfIdems = 0.0f;
    public float MaxNumberOfIdems;
    GameManager GameManager;
    float targetTime;
    bool end = false;
    bool wait = false;
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
        GameManager.EmployeeAI++;
    }

    void FixedUpdate()
    {
        TraversePoints();
    }

    void TraversePoints()
    {
        
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
