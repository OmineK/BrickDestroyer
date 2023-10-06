using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] UI ui;

    public bool levelComplete = false;

    bool doOnlyOnce = false;
    int ballsAlive;
    int bricksAlive;

    void Start()
    {
        bricksAlive = FindObjectsOfType<Brick>().Length;
        UpdateBricksAlive(0);
        Time.timeScale = 1;
    }

    void Update()
    {
        if (ballsAlive == 0)
            GameOver();

        if ((bricksAlive == 0) && (doOnlyOnce == false))
        {
            doOnlyOnce = true;
            LevelComplete();
        }

        GamePauseInput();
    }

    void GameOver()
    {
        ui.darkScreen.SetActive(true);
        ui.gameOverScreen.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Time.timeScale = 0;
    }

    void LevelComplete() => ui.LevelCompleteUI();

    void GamePauseInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (ui.gamePause == false)
                PauseGame();
            else
                UnpauseGame();

        }
    }

    void PauseGame()
    {
        ui.gamePause = true;
        ui.darkScreen.SetActive(true);
        ui.pauseScreen.SetActive(true);
        Time.timeScale = 0;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void UnpauseGame()
    {
        ui.darkScreen.SetActive(false);
        ui.pauseScreen.SetActive(false);

        ui.gamePause = false;
        Time.timeScale = 1;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void UpdateBallsAlive(int amount)
    {
        ballsAlive += amount;
        ui.UpdateGameBallsAliveUI(ballsAlive);
    }

    public void UpdateBricksAlive(int amount)
    {
        bricksAlive += amount;
        ui.UpdateBricksAliveUI(bricksAlive);
    }
}
