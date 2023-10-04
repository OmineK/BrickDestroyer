using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerSpeed;

    [NonSerialized] public List<GameObject> attractedBalls;
    [NonSerialized] public float magnetBuffTimer;

    public float maxPlatformSize { get; private set; } = 2.2f;
    public float minPlatformSize { get; private set; } = 0.6f;

    Rigidbody2D playerRB;

    void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();
        attractedBalls = new List<GameObject>();
    }

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        playerRB.velocity = new Vector3(horizontalInput * playerSpeed, 0, 0);
    }

    void Update()
    {
        MyInputs();
        MagnetBuffTimerCheck();
    }

    void MyInputs()
    {
        if ((attractedBalls.Count > 0) && Input.GetKeyDown(KeyCode.Space))
            ReleaseAllAttractedBalls();
    }

    void MagnetBuffTimerCheck()
    {
        magnetBuffTimer -= Time.deltaTime;

        //if magnet buff run out release all attracted balls
        if (magnetBuffTimer < 0 && (attractedBalls.Count > 0))
            ReleaseAllAttractedBalls();
    }

    void ReleaseAllAttractedBalls()
    {
        for (int i = attractedBalls.Count; i > 0; i--)
        {
            attractedBalls[i - 1].GetComponent<GameBall>().CancelBallAttracted();
            attractedBalls.Remove(attractedBalls[i - 1]);
        }
    }
}
