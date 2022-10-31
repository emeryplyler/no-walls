using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class align_script : MonoBehaviour
{
    public GameObject mainRoom, fakeRoom;
    public GameObject alignTo, toAlign;


    [SerializeField] public GameObject[] startingStair;
    [SerializeField] public GameObject[] destinationStair;
    [SerializeField] public int[] rotateBy;
    public int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        
        //fakeRoom.transform.position = Vector3(1002,0,-300);
        align(startingStair[i].transform,destinationStair[i].transform,rotateBy[i]);
        //align(startingStair[i+1].transform,destinationStair[i+1].transform,rotateBy[i+1]);
        
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    void align(Transform _alignTo, Transform _toAlign, int _rotate)
    {
        //print(_alignTo.rotation.y);

        
        
        //print(Mathf.Rad2Deg * _alignTo.rotation.y + " " + Mathf.Rad2Deg * _toAlign.rotation.y);
        print(_alignTo.rotation);
        print(_toAlign.rotation);
        //fakeRoom.transform.position = Vector3.zero;

        fakeRoom.transform.rotation = new Quaternion(0,0,0,1);
        fakeRoom.transform.Rotate(new Vector3(0,1,0), Quaternion.Angle(_toAlign.localRotation, _alignTo.localRotation) + _rotate);
        fakeRoom.transform.position = new Vector3(0,0,0);
//
        //fakeRoom.transform.rotation = Quaternion.LookRotation(_alignTo.position - _toAlign.position,Vector3.up);
        Vector3 to_trans = _alignTo.position - _toAlign.position ;
        fakeRoom.transform.position = to_trans;


    }
}
