using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBall : MonoBehaviour
{
    [SerializeField] float initialBallSpeed;
    [SerializeField] float maxBallSpeed;

    [NonSerialized] public Vector3 currentDirection;

    int xDirection = 1;
    float currentBallSpeed;

    Rigidbody2D ballRB;

    void Awake()
    {
        ballRB = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        currentBallSpeed = initialBallSpeed;
        SetupInitialVelocityToBall();
    }

    void FixedUpdate()
    {
        ControlBallVelocity();

        Debug.Log(currentBallSpeed);
    }

    void SetupInitialVelocityToBall()
    {
        GenerateRandomXDirection();
        ballRB.velocity = new Vector3(currentBallSpeed * xDirection, currentBallSpeed);
    }


    void ControlBallVelocity()
    {
        currentDirection = ballRB.velocity;
        currentDirection.Normalize();

        if (currentBallSpeed >= maxBallSpeed)
            currentBallSpeed = maxBallSpeed;

        ballRB.velocity = currentDirection * currentBallSpeed;
    }

    void GenerateRandomXDirection()
    {
        int randomXDir = UnityEngine.Random.Range(0, 2);

        if (randomXDir == 0)
            xDirection = 1;

        else if (randomXDir == 1)
            xDirection = -1;
    }

    public void IncreseBallSpeed()
    {
        if (currentBallSpeed >= maxBallSpeed) { return; }

        currentBallSpeed += 0.2f;
    }
}
