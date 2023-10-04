using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBallCollisionHandler : MonoBehaviour
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
        BottomBorderCollision(collision);
    }

    void PlayerCollision(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            Player player = collision.gameObject.GetComponent<Player>();

            gameBall.IncreseBallSpeed();            

            //if ball hit left side of player platform
            if (transform.position.x < player.transform.position.x - player.transform.localScale.x / 2)
                gameBall.ballRB.velocity = new Vector3(-6f, gameBall.ballRB.velocity.y);

            //if ball hit right side of player platform
            if (transform.position.x > player.transform.position.x + player.transform.localScale.x / 2)
                gameBall.ballRB.velocity = new Vector3(6f, gameBall.ballRB.velocity.y);

            //if ball hit the left-center of player platform
            if (transform.position.x > player.transform.position.x - player.transform.localScale.x / 2 &&
                transform.position.x < player.transform.position.x - player.transform.localScale.x / 4)
                gameBall.ballRB.velocity = new Vector3(-2f, gameBall.ballRB.velocity.y);

            //if ball hit the right-center of player platform
            if (transform.position.x < player.transform.position.x + player.transform.localScale.x / 2 &&
                transform.position.x > player.transform.position.x + player.transform.localScale.x / 4)
                gameBall.ballRB.velocity = new Vector3(2f, gameBall.ballRB.velocity.y);

            //if ball hit the center of player platform
            if (transform.position.x > player.transform.position.x - player.transform.localScale.x / 4 &&
                transform.position.x < player.transform.position.x + player.transform.localScale.x / 4)
                gameBall.ballRB.velocity = new Vector3(0, gameBall.ballRB.velocity.y);

            gameBall.SetupBallVelocity();
        }
    }

    void BrickCollision(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Brick>() != null)
            Destroy(collision.gameObject);
    }

    void BottomBorderCollision(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<BottomBorder>() != null)
        {
            gameBall.DecreaseBallCounter();
            gameBall.ballRB.velocity = new Vector3(0, 0);
        }
    }
}
