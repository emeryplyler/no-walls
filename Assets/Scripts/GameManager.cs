using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public GameObject coinSpawn;
    public float timer = 60;
    public float stopwatch = 0;
    public bool timerDone = false;
    private int coinsCollected = 0;

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
        stopwatch += Time.fixedDeltaTime;

        if (stopwatch > timer)
        {
            timerDone = true; 
        }

    }

    public void OnKeyCollect()
    {
        stopwatch = 0;
        timer -= 10;
        coinSpawn.GetComponent<SpawnCoin>().SpawnKey();
    }
}
