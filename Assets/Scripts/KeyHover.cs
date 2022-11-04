using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHover : MonoBehaviour
{
    private GameObject gameManager;
    private GameObject collectImage;

    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        collectImage = GameObject.Find("Canvas/CollectImage");
        collectImage.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (GetComponent<Collider>().Raycast(ray, out hit, 100f))
        {
            collectImage.SetActive(true);
            this.gameObject.GetComponent<Outline>().OutlineWidth = 2f;
            if (Input.GetKeyDown(KeyCode.F))
            {
                gameManager.GetComponent<GameManager>().OnKeyCollect();
                Destroy(this.gameObject);
            }
        }
        else
        {
            if (collectImage) collectImage.SetActive(false);
            this.gameObject.GetComponent<Outline>().OutlineWidth = 0f;
        }
    }
}
