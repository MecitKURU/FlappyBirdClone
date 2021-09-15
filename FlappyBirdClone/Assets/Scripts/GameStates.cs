using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStates : MonoBehaviour
{
    public Text scoreText;
    public GameObject pipes;
    public GameObject lostPanel;
    public bool isLost;

    public int score;
    void Start()
    {
        InvokeRepeating("CreatePipes", 0, 1.2f);
    }

    // Update is called once per frame
    void Update()
    {

        scoreText.text = "Score: " + score;

        if(isLost)
        {
            lostPanel.SetActive(true);

            if(Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if(touch.phase == TouchPhase.Began)
                {
                    Application.LoadLevel(0);
                }
            }
        }        
    }

    void CreatePipes()
    {
        if(!isLost)
            Instantiate(pipes);
    }

}
