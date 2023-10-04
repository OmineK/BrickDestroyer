using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] UI ui;

    [NonSerialized] public int ballsAlive;

    void Update()
    {
        if (ballsAlive == 0)
            GameOver();
    }

    void GameOver()
    {
        Debug.Log("game over");
    }
}
