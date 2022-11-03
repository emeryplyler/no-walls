using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleportScript : MonoBehaviour
{
    // Start is called before the first frame update

    bool movingTowards = true;
    public GameObject thisStair;
    public GameObject targetPortal;
    public GameObject playerReference;
    public float angleBy = 0;
    public bool readyToTeleport = true;
    private float distanceToPlayer = 0;
    private float teleportThreshold = 3;
    public align_script alignmentScript;
    private BoxCollider thisCollider;
    private Camera  portalCam;
    public Camera playerCam;
    public MeshRenderer screen;
    public RenderTexture viewTexture;

    
// portal visual logic credit https://www.youtube.com/watch?v=cWpFZbjtSQg&ab_channel=SebastianLague 

    void Awake()
    {
        thisCollider = this.GetComponent<BoxCollider>();
        portalCam = GetComponentInChildren<Camera>();
        portalCam.enabled = false;
        screen = GetComponent<MeshRenderer>();
    }
    void CreateViewTexture()
    {
        if (viewTexture == null || viewTexture.width != Screen.width || viewTexture.height != Screen.height)
        {
            if (viewTexture != null)
            {
                viewTexture.Release();
            }
            viewTexture = new RenderTexture(Screen.width,Screen.height,0);

            portalCam.targetTexture = viewTexture;
            targetPortal.GetComponent<teleportScript>().screen.material.SetTexture("_MainTex", viewTexture);
        }
    }


    void Render()
    {
        //print("ttttt");
        screen.enabled = false;
        CreateViewTexture();
        var m = transform.localToWorldMatrix * targetPortal.transform.worldToLocalMatrix * playerCam.transform.localToWorldMatrix;
        
        portalCam.transform.SetPositionAndRotation(m.GetColumn(3),m.rotation);
        
        portalCam.Render();
        screen.enabled = true;
    }

    // void OnBecameVisible()
    // {
    //     int index = System.Array.IndexOf(alignmentScript.startingStair,thisStair);
    //     alignmentScript.align(alignmentScript.startingStair[index].transform,
    //         alignmentScript.destinationStair[index].transform,alignmentScript.rotateBy[index]);
    // }

    void OnTriggerExit(Collider other)
    {
       

        if (other.name == "Capsule" && readyToTeleport)
        {
            //set player position
            PlayerMovement playerScript = other.GetComponent<PlayerMovement>();
            Vector3 portalOffset = Quaternion.AngleAxis(angleBy,Vector3.up) * (playerReference.transform.position - this.transform.position);
            playerScript.teleport(targetPortal.transform.position + portalOffset,angleBy);
            //set other portal reference
            teleportScript tpScript =  targetPortal.GetComponent<teleportScript>();
          //  tpScript.readyToTeleport = false;


        }
    }



    // void OnTriggerExit(Collider other)
    // {
    //     if (other.name == "Capsule")
    //     {
    //         readyToTeleport = true;

    //     }
    // }

    // Update is called once per frame
    // void Update()
    // {
    //     distanceToPlayer = Vector3.Distance(thisStair.transform.position,playerReference.transform.position);

    //     Vector3 thisforward = this.thisStair.transform.forward;
    //     //Vector3 vect_dist = Quaternion.Euler(0,angleBy,0) * (thisStair.transform.position - playerReference.transform.position);
    //     if((distanceToPlayer < teleportThreshold ) && gracePeriod == false)
    //     {
    //         PlayerMovement playerScript = playerReference.GetComponent<PlayerMovement>();
    //         Vector3 teleportBy =  (targetStair.transform.position - thisStair.transform.position );
    //         playerScript.teleport(teleportBy, angleBy);
            
    //         teleportScript targetScript = targetStair.GetComponent<teleportScript>();
    //         targetScript.setGrace();
            
    //     }
    //     else if (distanceToPlayer > teleportThreshold + 1)
    //     {
    //         gracePeriod = false;
    //     }
    // }

}
