using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointManager : MonoBehaviour
{
    public string RoomName = "";
    public bool left;
    public float turn;

    void Start()
    {
        if(left)
        {
            turn = 90.0f;
        }else
        {
            turn = -90.0f;
        }
    }
}