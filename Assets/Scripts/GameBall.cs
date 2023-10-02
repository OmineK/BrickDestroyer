using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBall : MonoBehaviour
{
    [SerializeField] float initialBallSpeed;
    public float maxBallSpeed;

    [NonSerialized] public int xDirection = 1;
    [NonSerialized] public int yDirection = 1;
    [NonSerialized] public float currentBallSpeed;

    [NonSerialized] public Rigidbody2D gameBallRB;

    void Awake()
    {
        gameBallRB = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        currentBallSpeed = initialBallSpeed;
        GenerateRandomXDirection();
    }

    void FixedUpdate()
    {
        BallMovement();
    }

    void BallMovement()
    {
        gameBallRB.velocity = new Vector3(currentBallSpeed * xDirection, currentBallSpeed * yDirection, 0);
    }

    void GenerateRandomXDirection()
    {
        int randomXDir = UnityEngine.Random.Range(0, 2);

        if (randomXDir == 0)
            xDirection = 1;

        else if (randomXDir == 1)
            xDirection = -1;
    }
}
