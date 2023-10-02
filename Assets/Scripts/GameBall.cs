using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBall : MonoBehaviour
{
    [SerializeField] float initialBallSpeed;
    [SerializeField] float maxBallSpeed;

    int xDirection = 1;

    float currentBallSpeed;

    [NonSerialized] public Rigidbody2D ballRB;

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
        Debug.Log("Magnitude: " + ballRB.velocity.magnitude);
        Debug.Log("Speed: " + currentBallSpeed);
    }

    void SetupInitialVelocityToBall()
    {
        GenerateRandomXDirection();
        ballRB.velocity = new Vector3(currentBallSpeed * xDirection, currentBallSpeed);
    }


    private void ControlBallVelocity()
    {
        Vector3 currentDirection = ballRB.velocity;
        currentDirection.Normalize();

        if (ballRB.velocity.magnitude >= maxBallSpeed)
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
