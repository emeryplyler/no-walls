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
    public bool locked = true;
    public GameObject player;

    void Awake()
    {
        instance = this; 

    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Capsule");
    }

    // Update is called once per frame
    void Update() 
    {
        stopwatch += Time.fixedDeltaTime;

        if (stopwatch > timer)
        {
            timerDone = true; 
        }
        
        if (coinsCollected == 3){
            locked = false;
        }
    }

    public void OnKeyCollect()
    {
        stopwatch = 0;
        timer -= 10;
        coinSpawn.GetComponent<SpawnCoin>().SpawnKey();
    }

    void OnGUI(){
        if (timerDone == true){
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "You are Dead!");
            player.GetComponent<PlayerMovement>().enabled = false;
        }
    }
}
