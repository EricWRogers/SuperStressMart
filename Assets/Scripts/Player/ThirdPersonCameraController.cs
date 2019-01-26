using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCameraController : MonoBehaviour
{
    public float RotationSpeed = 2.0f;
    public Transform Target, Player;

    private float mouseX, mouseY;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        CanControl();
    }

    void CanControl()
    {
        mouseX += (Input.GetAxis("Mouse X") * RotationSpeed) * Time.deltaTime;
        mouseY -= (Input.GetAxis("Mouse Y") * RotationSpeed) * Time.deltaTime;

        mouseY = Mathf.Clamp(mouseY, 20.0f, 60.0f);
        // mouseX = Mathf.Clamp(mouseX, 0.0f, 360.0f);

        // Debug.Log("MouseY: " + mouseY + " MouseX: " + mouseX);

        //transform.LookAt(Target);

        Target.rotation = Quaternion.Euler(mouseY, mouseX, 0.0f);
        Player.rotation = Quaternion.Euler(0.0f, mouseX, 0.0f);
        //transform.LookAt(Target);
    }
}
