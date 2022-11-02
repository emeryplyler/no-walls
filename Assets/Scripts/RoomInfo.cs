using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomInfo : MonoBehaviour
{
    [Header("Room Detail")]
    public string name;
    public Vector3 center;

    void Start()
    {
        this.transform.position = center;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
