using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    GameBall gameBall;

    void Awake()
    {
        gameBall = GetComponent<GameBall>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerCollision(collision);
        BrickCollision(collision);
    }

    void PlayerCollision(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            Player player = collision.gameObject.GetComponent<Player>();

            gameBall.IncreseBallSpeed();            

            //if ball hit left side of player platform
            if (player.transform.position.x > player.transform.position.x - player.transform.localScale.x / 2)
            {
                float randomBoostX = UnityEngine.Random.Range(0.5f, 3.5f);
                gameBall.currentDirection = new Vector3(100, 100);
            }

            //if ball hit right side of player platform
            if (player.transform.position.x < player.transform.position.x + player.transform.localScale.x / 2)
            {
                float randomReduceX = UnityEngine.Random.Range(-0.5f, 3.5f);
                gameBall.currentDirection = new Vector3(100, 100);
            }
        }
    }

    void BrickCollision(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Brick>() != null)
        {
            Destroy(collision.gameObject);
        }
    }
}
