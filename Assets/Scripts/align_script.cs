using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class align_script : MonoBehaviour
{
    public GameObject mainRoom, fakeRoom;
    public GameObject alignTo, toAlign;
    // Start is called before the first frame update
    void Start()
    {
        align(alignTo.transform,toAlign.transform);
        //fakeRoom.transform.position = Vector3(1002,0,-300);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void align(Transform _alignTo, Transform _toAlign)
    {
        fakeRoom.transform.rotation = _alignTo.rotation;
        fakeRoom.transform.position = Vector3.zero;

        Vector3 to_trans = _alignTo.position - _toAlign.position ;

        fakeRoom.transform.position = to_trans;


    }
}
