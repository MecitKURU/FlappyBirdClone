using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipes : MonoBehaviour
{
    float posY;
    float speed;
    GameStates gameStates;

    Transform player;

    bool scoreIncreaseOnce;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        gameStates = GameObject.Find("GameStates").GetComponent<GameStates>();
        speed = 5;
        posY = Random.Range(-2.5f, 2.5f);

        transform.position = new Vector3(6, posY, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameStates.isLost)
            transform.Translate(-speed * Time.deltaTime, 0, 0);

        if(transform.position.x < player.position.x)
        {
            if (!scoreIncreaseOnce)
            {
                gameStates.score += 10;
                scoreIncreaseOnce = true;
            }
        }
    }
}
