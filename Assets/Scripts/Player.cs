using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float playerSpeed;

    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        rb.velocity = new Vector3(horizontalInput * playerSpeed, 0, 0);
        BlockMoveOutsideCamera();
    }

    void Update()
    {
        PlayerInputs();
    }

    void BlockMoveOutsideCamera()
    {
        if (transform.position.x <= -10)
            transform.position = new Vector3(-10, transform.position.y, 0);

        if (transform.position.x >= 10)
            transform.position = new Vector3(10, transform.position.y, 0);
    }

    void PlayerInputs()
    {
        //TODO
    }
}
