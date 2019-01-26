using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCharacterController : MonoBehaviour
{
    public float Speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        Debug.Log("Hor: " + Input.GetAxis("Horizontal") + " Ver: " + Input.GetAxis("Vertical"));
        transform.Translate(new Vector3(Input.GetAxis("Horizontal"), 0.0f,Input.GetAxis("Vertical")) * Speed * Time.deltaTime, Space.Self);
    }
}
