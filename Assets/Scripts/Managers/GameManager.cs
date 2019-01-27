using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject PlayerGO;
    public GameObject[] RoomGOS;
    public GameObject[] CheckStand;
    public GameObject enter;
    public GameObject exit;
    public bool spawn;
    public GameObject Coustomer;
    public GameObject Employee;
    public float spawnTime = 3f;
    public float maxCoustomerAI = 10f;
    public float coustomerAI= 0f;
    public float maxEmployeeAI = 10f;
    public float EmployeeAI= 0f;
    // Start is called before the first frame update
    void Awake()
    {
        RoomGOS = GameObject.FindGameObjectsWithTag("WayPoint");
        PlayerGO = GameObject.FindGameObjectWithTag("Player");
        CheckStand = GameObject.FindGameObjectsWithTag("CheckStand");
        enter = GameObject.FindGameObjectWithTag("Enter Door");
        exit = GameObject.FindGameObjectWithTag("Exit Door");
    }
    void Update()
    {
        waitTimer();
    }
    void FixedUpdate()
    {
        if(coustomerAI == maxCoustomerAI)
        {
            maxCoustomerAI = Random.Range(10,14);
            spawn = false;
            
        } else if(coustomerAI < maxCoustomerAI && spawn)
        {
            //Instantiate(Coustomer,enter.transform);
            spawn = false;
        }
    }

    void waitTimer()
    {
        if(coustomerAI <= maxCoustomerAI)
        {
            spawnTime -= Time.deltaTime;
        
            if (spawnTime <= 0.0f)
            {
                spawnTime = Random.Range(3,5);
                spawn = true;
            }
        }

    }
}
