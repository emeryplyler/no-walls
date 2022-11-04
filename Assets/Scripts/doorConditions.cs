using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorConditions : MonoBehaviour
{
    private bool showText = false;
    private bool showWinningText = false;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Capsule");
    }

    void OnMouseDown(){
        // if text isn't showing
        if (!showText && !GameManager.instance.won){
            showText = true;
        } else if (GameManager.instance.won){
            showWinningText = true;
            GameManager.instance.gameOver = true;
        }
    }

    void OnGUI(){
        GUIStyle myButton = new GUIStyle(GUI.skin.button);
        myButton.fontSize = 15;
        myButton.normal.textColor = Color.red;

        GUIStyle winButton = new GUIStyle(GUI.skin.button);
        winButton.fontSize = 30;
        winButton.normal.textColor = Color.green;

        GUIStyle testS = new GUIStyle("WarningStyle");

        // if it's locked, show text that it's locked
        if (showText && GameManager.instance.locked && !GameManager.instance.timerDone){
            if (GUI.Button(new Rect(0, 0, Screen.width, Screen.height/10), "Door is Locked", myButton)){
                showText = false;
            }
        } else if (showText && !GameManager.instance.locked && !GameManager.instance.timerDone){
            if (GUI.Button(new Rect(0, 0, Screen.width, Screen.height/10), "Door is Unlocked", myButton)){
                showText = false;
            }
        } else if (showWinningText){
            GUI.Button(new Rect(0, 0, Screen.width, Screen.height), "You've Escaped!", winButton);
            GameManager.instance.gameOver = true;
        }
    }
}
