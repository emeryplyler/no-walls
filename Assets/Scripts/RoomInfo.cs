using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomInfo : MonoBehaviour
{
    [Header("Room Detail")]
    public string name;
    public Vector3 center;

    void Start() {
        center = this.transform.position;
    }

    // Can be used to animate the key parts
    void Update() {
        
    }
}
