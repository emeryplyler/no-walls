using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHover : MonoBehaviour
{
    private GameObject gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }
    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (GetComponent<Collider>().Raycast(ray, out hit, 100f))
        {
            this.gameObject.GetComponent<Outline>().OutlineWidth = 2f;
            if (Input.GetKeyDown(KeyCode.F))
            {
                gameManager.GetComponent<GameManager>().OnKeyCollect();
                Destroy(this.gameObject);
            }
        }
        else
        {
            this.gameObject.GetComponent<Outline>().OutlineWidth = 0f;
        }
    }
}
