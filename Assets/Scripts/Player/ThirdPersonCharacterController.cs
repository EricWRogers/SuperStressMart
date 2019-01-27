using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCharacterController : MonoBehaviour
{
    public float Speed;
    public float OriginalSpeed;
    Animator anim;
    public UI ui;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        OriginalSpeed = Speed;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            anim.SetBool("Walking", true);
        }
        else
        {
            anim.SetBool("Walking", false);
        }

        Debug.Log("Hor: " + Input.GetAxis("Horizontal") + " Ver: " + Input.GetAxis("Vertical"));
        transform.Translate(new Vector3(Input.GetAxis("Horizontal"), 0.0f,Input.GetAxis("Vertical")) * Speed * Time.deltaTime, Space.Self);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "end")
        {
            Debug.Log("end");
            ui.Win();
        }
    }
}
