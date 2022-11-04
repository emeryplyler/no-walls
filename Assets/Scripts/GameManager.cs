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
    public bool won = false;

    private GameObject collectImage;

    void Awake()
    {
        instance = this; 

    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Capsule");
        collectImage = GameObject.Find("Canvas/CollectImage");
    }

    // Update is called once per frame
    void Update() 
    {
        stopwatch += Time.deltaTime;

        if (stopwatch > timer)
        {
            timerDone = true;
            stopwatch = 0;
        }
        
        if (coinsCollected == 3){
            locked = false;
            won = true;
            collectImage.SetActive(false);
        }
    }

    public void OnKeyCollect()
    {
        stopwatch = 0;
        timer -= 10;
        coinSpawn.GetComponent<SpawnCoin>().SpawnKey();
        coinsCollected ++;
    }

    void OnGUI(){
        GUIStyle dieButton = new GUIStyle(GUI.skin.button);
        dieButton.fontSize = 30;
        dieButton.normal.textColor = Color.red;

        if (timerDone == true && won == false){
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "You are Dead!", dieButton);
            player.GetComponent<PlayerMovement>().enabled = false;
        }
    }
}
