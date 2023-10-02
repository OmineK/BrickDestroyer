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
        if (collision.gameObject.GetComponent<Player>())
        {
            gameBall.yDirection *= -1;
            gameBall.gameBallRB.AddForce(new Vector3(0, 4));
        }

        if (collision.transform.position.y > transform.position.y &&
            collision.transform.position.x == 0)
            gameBall.yDirection *= -1;

        if ((collision.transform.position.x > transform.position.x && collision.transform.position.y == 0) ||
            (collision.transform.position.x < transform.position.x && collision.transform.position.y == 0))
            gameBall.xDirection *= -1;

        //TODO: if game object is brick

        //TODO: Delete above if after tests
        if (collision.transform.position.y < transform.position.y &&
            collision.transform.position.x == 0)
            gameBall.yDirection *= -1;
    }
}
