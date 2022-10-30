using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public float timer = 60;
    public float stopwatch = 0;
    public bool timerDone = false;

    void Awake()
    {
        instance = this; 

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() 
    {
        stopwatch += Time.deltaTime;

        if (stopwatch > timer)
        {
            timerDone = true; 
        }



    }
}
