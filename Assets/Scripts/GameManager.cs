using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{

    public AudioSource music;
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
    public bool gameOver = false;

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


        if (countDown <= 25){
            SoundManager.instance.PlayHere(2, music);
        }

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
        timer -= 15;
        coinSpawn.GetComponent<SpawnCoin>().SpawnKey();
        coinsCollected ++;
    }

    void OnGUI(){
        GUIStyle dieButton = new GUIStyle(GUI.skin.button);
        dieButton.fontSize = 30;
        dieButton.normal.textColor = Color.red;

        if (timerDone == true && won == false){
            SoundManager.instance.StopSoundHere(2, music);
            SoundManager.instance.PlayGlobal(1);
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "You are Dead! Press F to restart!", dieButton);
            if (Input.GetKeyDown(KeyCode.F)){
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            player.GetComponent<PlayerMovement>().enabled = false;
        }

        GUIStyle timerButt = new GUIStyle(GUI.skin.button);
        timerButt.fontSize = 20;
        timerButt.normal.textColor = Color.white;

        if (!gameOver){
            GUI.Box(new Rect(0, Screen.height-30, Screen.width, 30), countDown.ToString("#00"), timerButt);
        }
    }
}
