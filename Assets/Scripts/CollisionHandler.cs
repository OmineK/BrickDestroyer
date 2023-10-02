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
            if (transform.position.x < player.transform.position.x - player.transform.localScale.x / 2)
            {
                float randomNegativeX = UnityEngine.Random.Range(-8f, -5f);
                gameBall.ballRB.velocity = new Vector3(randomNegativeX, gameBall.ballRB.velocity.y);
            }

            //if ball hit right side of player platform
            if (transform.position.x > player.transform.position.x + player.transform.localScale.x / 2)
            {
                float randomPositivetX = UnityEngine.Random.Range(5f, 8f);
                gameBall.ballRB.velocity = new Vector3(randomPositivetX, gameBall.ballRB.velocity.y);
            }

            gameBall.SetupBallVelocity();
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
