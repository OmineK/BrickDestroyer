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
            gameBall.IncreseBallSpeed();
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
