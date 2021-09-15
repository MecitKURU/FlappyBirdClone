using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D myRigidbody;
    public float jumpForce;

    GameStates gameStates;
    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        gameStates = GameObject.Find("GameStates").GetComponent<GameStates>();
    }

    private void Update()
    {

        if(transform.position.y >= 5.5f || transform.position.y <= -5.5f)
        {
            gameStates.isLost = true;
        }


        if (!gameStates.isLost)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    myRigidbody.velocity = Vector2.zero;
                    myRigidbody.AddForce(Vector2.up * jumpForce);

                    transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, 60);
                }
            }

            else
            {
                transform.localEulerAngles = Vector3.Lerp(transform.localEulerAngles, new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, 0), Time.deltaTime);
            }

        }
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Pipe")
        {
            myRigidbody.gravityScale = 0;
            myRigidbody.velocity = Vector2.zero;
            gameStates.isLost = true;
        }
    }
}
