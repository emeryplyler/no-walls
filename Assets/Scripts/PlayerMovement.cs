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
    [Tooltip("The amount to subtract from the player's Y velocity every update when gravity affects them.\nGets multiplied by Time.deltaTime .")]
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
        if (GameManager.instance.gameOver){
            return;
        }
        // Update camera
        float mouseX = Input.GetAxisRaw("Mouse X") * mouseSensitivity * Time.fixedDeltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * mouseSensitivity * Time.fixedDeltaTime;

        camYRot += mouseX;
        camXRot -= mouseY;
        camXRot = Mathf.Clamp(camXRot, -90f, 90f); // Prevent looking past straight up and straight down

        myCamera.transform.rotation = Quaternion.Euler(camXRot, camYRot, 0);

        // Gravity
        yVel = myController.isGrounded ? 0f : yVel - gravVelDelta * Time.deltaTime;

        // Update movement
        float horizontalMouseInput = Input.GetAxis("Horizontal");
        float verticalMouseInput = Input.GetAxis("Vertical");
        Vector3 movVector = new Vector3(horizontalMouseInput, yVel, verticalMouseInput);
        movVector = Vector3.ClampMagnitude(movVector, 1f); // Prevent going faster diagonally

        Quaternion movRotationQuat = Quaternion.Euler(0, camYRot, 0); // Camera's rotation about y axis
        movVector = movRotationQuat * movVector;

        myController.Move(movVector * Time.deltaTime * movSpeed);

        // Raycast for dummy room alignment
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
