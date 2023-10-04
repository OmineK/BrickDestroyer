using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameBall : MonoBehaviour
{
    [SerializeField] float initialBallSpeed;
    [SerializeField] float maxBallSpeed;

    [NonSerialized] public bool ballAttracted = false;
    [NonSerialized] public Vector3 currentDirection;
    [NonSerialized] public GameManager gameManager;
    [NonSerialized] public Rigidbody2D ballRB;

    int xDirection = 1;
    float currentBallSpeed;

    void Awake()
    {
        ballRB = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        currentBallSpeed = initialBallSpeed;
        SetupStartDirection();
        SetupBallVelocity();
        gameManager.ballsAlive++;
    }

    void FixedUpdate()
    {
        ControlBallVelocity();
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

    public void CancelBallAttracted()
    {
        ballRB.isKinematic = false;

        //if ball is on the left side of player platform
        if (transform.localPosition.x < -0.2f)
            ballRB.velocity = new Vector3(UnityEngine.Random.Range(-6f, -0.5f), currentBallSpeed);

        //if ball is on the right side of player platform
        if (transform.localPosition.x > 0.2f)
            ballRB.velocity = new Vector3(UnityEngine.Random.Range(0.5f, 6f), currentBallSpeed);

        //if ball is on the center of player platform
        if (transform.localPosition.x > -0.2f && transform.localPosition.x < 0.2f)
            ballRB.velocity = new Vector3(UnityEngine.Random.Range(-1f, 1f), currentBallSpeed);

        SetupBallVelocity();
        transform.parent = null;
        ballAttracted = false;
    }

    public void DecreaseBallCounter() => gameManager.ballsAlive--;
}
