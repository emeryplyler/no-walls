using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Movement code partially based off of code from this tutorial: https://www.youtube.com/watch?v=f473C43s8nE
*/ 

public class PlayerMovement : MonoBehaviour
{
    // Variables for player camera
    public float mouseSensitivity = 1500f;
    public Camera myCamera;
    private float camXRot;
    private float camYRot;

    // Variables for 8-way movement
    public CharacterController myController;
    public float movSpeed = 10f;

    [SerializeField] align_script alignment_script;
    // Gravity
    private float yVel;
    [Tooltip("The amount to subtract from the player's Y velocity every update when gravity affets them.\nGets multiplied by Time.deltaTime .")]
    public float gravVelDelta = 100f;
    
    // Start is called before the first frame update
    void Start()
    {
        // Reset cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        myCamera = GetComponentInChildren<Camera>();
        myController = gameObject.GetComponent<CharacterController>();

        
    }

    // Update is called once per frame
    void Update()
    {
        // Update camera
        float mouseX = Input.GetAxisRaw("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * mouseSensitivity * Time.deltaTime;

        camYRot += mouseX;
        camXRot -= mouseY;
        camXRot = Mathf.Clamp(camXRot, -90f, 90f); // Prevent looking past straight up and stright down

        myCamera.transform.rotation = Quaternion.Euler(camXRot, camYRot, 0);

        // Gravity
        if (myController.isGrounded)
        {
            yVel = 0f;
        }
        else
        {
            yVel -= gravVelDelta * Time.deltaTime;
        }

        // Update movement
        Vector3 movVector = new Vector3(Input.GetAxis("Horizontal"), yVel, Input.GetAxis("Vertical"));
        Quaternion movRotationQuat = Quaternion.Euler(0, camYRot, 0); // Camera's rotation about y axis
        movVector = movRotationQuat * movVector;

        myController.Move(movVector * Time.deltaTime * movSpeed);


        handleRaycast();
    }
    void handleRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(myCamera.transform.position,myCamera.transform.forward, out hit))
        {
            Vector3 result = hit.point;
            alignment_script.checkToAlign(result);
            //this.alignment_script.checkToAlign(result);
        }
    }
    public void teleport(Vector3 teleportBy,  float rotation)
    {
        transform.position = teleportBy;
        Physics.SyncTransforms();

        camYRot += rotation;
        //camXRot = rotation.eulerAngles.x;


        
    }

}
