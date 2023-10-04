using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [NonSerialized] public int ballsAlive;

    void Update()
    {
       Invoke(nameof(GameOver), 0.1f);
    }

    void GameOver()
    {
        if (ballsAlive == 0)
            Debug.Log("game over");
    }
}
