using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float playerSpeed;

    public float maxPlatformSize { get; private set; } = 2.2f;
    public float minPlatformSize { get; private set; } = 0.6f;

    Rigidbody2D playerRB;

    void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        playerRB.velocity = new Vector3(horizontalInput * playerSpeed, 0, 0);
    }

    void Update()
    {
        PlayerInputs();
    }

    void PlayerInputs()
    {
        //TODO
    }
}
