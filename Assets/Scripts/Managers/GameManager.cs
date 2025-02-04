﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float StressBar = 0.0f;
    public GameObject PlayerGO;
    public GameObject[] RoomGOS;
    public GameObject[] CheckStand;
    public GameObject enter;
    public GameObject exit;
    private bool spawn;
    public bool isChasing = false;
    public GameObject Coustomer;
    private GameObject Employee;
    private float spawnTime = 3f;
    public float maxCoustomerAI = 30.0f;
    public float coustomerAI;
    public float fireTimeLeft = 60.0f;
    
    AudioManager audio;
    
    // Start is called before the first frame update
    void Awake()
    {
        RoomGOS = GameObject.FindGameObjectsWithTag("WayPoint");
        PlayerGO = GameObject.FindGameObjectWithTag("Player");
        CheckStand = GameObject.FindGameObjectsWithTag("CheckStand");
        enter = GameObject.FindGameObjectWithTag("Enter Door");
        exit = GameObject.FindGameObjectWithTag("Exit Door");
        audio=this.GetComponent<AudioManager>();
    }
    void Update()
    {
        waitTimer();
        fireTimer();
    }
    void FixedUpdate()
    {
        if(coustomerAI == maxCoustomerAI)
        {
            maxCoustomerAI = UnityEngine.Random.Range(10,14);
            spawn = false;
            
        } else if(coustomerAI < maxCoustomerAI && spawn)
        {
            Instantiate(Coustomer,enter.transform);
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
                spawnTime = UnityEngine.Random.Range(3,5);
                spawn = true;
            }
        }
    }
    void fireTimer()
    {
        if(fireTimeLeft > 0.0f)
        {
            fireTimeLeft -= Time.deltaTime;
            if(fireTimeLeft <= 0.0f)
            {
                audio.SoundsEventTrigger(SoundEvents.FireAlarm);
                fireTimeLeft = UnityEngine.Random.Range(90.0f,120.0f);
            }
        }
    }

    public void Chasing(bool BoldHolder)
    {
        isChasing = BoldHolder;
        if (BoldHolder)
        {
            PlayerGO.GetComponent<ThirdPersonCharacterController>().Speed = PlayerGO.GetComponent<ThirdPersonCharacterController>().OriginalSpeed * 2;
        }
        else
        {
            PlayerGO.GetComponent<ThirdPersonCharacterController>().Speed = PlayerGO.GetComponent<ThirdPersonCharacterController>().OriginalSpeed;
        }
    }

    public void ChangeStress(float mod)
    {
        StressBar = StressBar + mod;
    }
}
