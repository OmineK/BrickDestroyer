using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBall : MonoBehaviour
{
    [SerializeField] float initialBallSpeed;
    [SerializeField] float maxBallSpeed;

    [NonSerialized] public Vector3 currentDirection;
    [NonSerialized] public Rigidbody2D ballRB;

    int xDirection = 1;
    float currentBallSpeed;

    void Awake()
    {
        ballRB = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        currentBallSpeed = initialBallSpeed;
        SetupStartDirection();
        SetupBallVelocity();
    }

    void FixedUpdate()
    {
        ControlBallVelocity();

        Debug.Log("magnitude: " + ballRB.velocity.magnitude);
        Debug.Log("speed: " + currentBallSpeed);
    }

    void SetupStartDirection()
    {
        GenerateRandomXDirection();
        ballRB.velocity = new Vector3(currentBallSpeed * xDirection, currentBallSpeed);
    }


    void ControlBallVelocity()
    {
        if (currentBallSpeed >= maxBallSpeed)
        {
            currentBallSpeed = maxBallSpeed;
            SetupBallVelocity();
        }
   
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

    public void SetupBallVelocity()
    {
        currentDirection = ballRB.velocity;
        currentDirection.Normalize();

        ballRB.velocity = currentDirection * currentBallSpeed;
    }
}
