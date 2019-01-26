﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject PlayerGO;
    public GameObject[] RoomGOS;
    public GameObject[] CheckStand;
    public GameObject enter;
    public GameObject exit;
    // Start is called before the first frame update
    void Awake(){
        RoomGOS = GameObject.FindGameObjectsWithTag("WayPoint");
        PlayerGO = GameObject.FindGameObjectWithTag("Player");
        CheckStand = GameObject.FindGameObjectsWithTag("CheckStand");
        enter = GameObject.FindGameObjectWithTag("Enter Door");
        exit = GameObject.FindGameObjectWithTag("Exit Door");
    }
    void Update(){}
    void FixedUpdate()
    {
        PollAgression();
    }
    private void PollAgression()
    {
        foreach(GameObject waypoint in RoomGOS)
        {
            //if ( Vector3.Distance(waypoint.transform.position, PlayerGO.transform.position) < 10.0f )
            {
                //WavePointManager RoomManager = waypoint.GetComponent<WavePointManager>();
                //RoomManager.agressionMeter =  RoomManager.agressionMeter + 0.1f;
                //if( RoomManager.agressionMeter > 100.0f) { RoomManager.agressionMeter = 100.0f; }
            }
        }
    }
}
