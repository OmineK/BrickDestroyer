using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] UI ui;

    public float playerSpeed;

    [NonSerialized] public List<GameObject> attractedBalls;
    public float magneticBuffTimer;

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
        MagneticTimerUI();
    }

    void MyInputs()
    {
        if ((attractedBalls.Count > 0) && Input.GetKeyDown(KeyCode.Space))
            ReleaseAllAttractedBalls();
    }

    void MagnetBuffTimerCheck()
    {
        magneticBuffTimer -= Time.deltaTime;

        //if magnet buff run out release all attracted balls
        if (magneticBuffTimer < 0 && (attractedBalls.Count > 0))
            ReleaseAllAttractedBalls();
    }

    void MagneticTimerUI()
    {
        if (magneticBuffTimer > 0)
        {
            ui.ShowMagneticBuffTimerUI(true);
            ui.UpdateMagneticBuffTimerUI(magneticBuffTimer);
        }
        else
            ui.ShowMagneticBuffTimerUI(false);
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
