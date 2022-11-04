using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public Text timerText;
    public float countDown;

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
        countDown = timer-stopwatch;

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

        GUIStyle timerButt = new GUIStyle(GUI.skin.button);
        timerButt.fontSize = 15;
        timerButt.normal.textColor = Color.white;

        GUI.Box(new Rect(0, Screen.height-20, Screen.width, 20), countDown.ToString("#00"), timerButt);
    }
}
