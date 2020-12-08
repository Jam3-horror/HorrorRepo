using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rB;
    private Transform Camtransform;
    public Camera cam;
    Vector3 input;


    [Header("Character Setup")]
    public float speed;
    public float runSpeed;
    [Header("Camera Setup")]
    public float MaxY = 60f;
    public float MinY = -60f;
    public float SensitivityY = 0.0f;
   private float rotationY = 0;

    void Start()
    {

        Camtransform = Camera.main.transform;
        rB = GetComponent<Rigidbody>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
       input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")); // getting the input vector
        rotationY += Input.GetAxis("Mouse Y") * SensitivityY;
        rotationY = Mathf.Clamp(rotationY, MinY, MaxY); // clamping rotation y to min and max whihc can be set in insepector 
        if (rotationY != 0)
        {
            
            cam.transform.localEulerAngles = new Vector3(-rotationY, 0, 0); // rotating the camera on the y
        }

    }
    private void FixedUpdate()
    {
   
       
            PlayerMove();
      
    }
    void PlayerMove()
    {
        float LookDir = (Input.GetAxis("Mouse X"));
        Vector3 forward = Camtransform.forward; //transform.forward;
        Vector3 right = Camtransform.right; //transform.right;

        right.y = 0;

        forward.Normalize();
        right.Normalize();

        Vector3 DesMoveDir = (forward * input.z + right * input.x).normalized; // creating a vector that takes the input directions and multiplies them with the forward and side of camera so the player moves where it is looking 

        Vector3 DesLookDir = (right * LookDir).normalized; // normalising the look directon

        rB.velocity = DesMoveDir.normalized * speed + new Vector3(0.0f, rB.velocity.y, 0.0f); // setting the velocity of the player so he moves


        //if (Input.GetKey(KeyCode.Joystick1Button8))
        //{
        //    rB.velocity = DesMoveDir * runSpeed + new Vector3(0.0f, rB.velocity.y, 0.0f);
        //}
        if (DesLookDir != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(DesLookDir.normalized), 0.05f);
        }
    }
}
