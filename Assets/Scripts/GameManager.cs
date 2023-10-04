using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] UI ui;

    [NonSerialized] public int ballsAlive;
    public int bricksAlive;

    void Start()
    {
        bricksAlive = FindObjectsOfType<Brick>().Length;
    }

    void Update()
    {
        if (ballsAlive == 0)
            GameOver();

        if (bricksAlive == 0)
            LevelComplete();
    }

    void GameOver()
    {
        Debug.Log("game over");
    }

    void LevelComplete()
    {
        Debug.Log("Level complete");
    }
}
