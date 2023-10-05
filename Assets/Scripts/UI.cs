using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] TextMeshProUGUI ballsAliveNumberText;
    [SerializeField] TextMeshProUGUI bricksLeftNumberText;
    [SerializeField] TextMeshProUGUI magneticBuffTimerText;

    public GameObject darkScreen;
    public GameObject gameOverScreen;
    public GameObject levelCompleteScreen;
    public GameObject pauseScreen;

    [NonSerialized] public bool gamePause = false;

    void Start()
    {
        darkScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        levelCompleteScreen.SetActive(false);
        pauseScreen.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void ResumeButton() => gameManager.UnpauseGame();

    public void PlayAgainButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToMenuButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void LevelCompleteUI()
    {
        darkScreen.SetActive(true);
        levelCompleteScreen.SetActive(true);
        gameManager.levelComplete = true;
        Invoke(nameof(LoadNextScene), 3f);
    }

    void LoadNextScene()
    {
        Time.timeScale = 1;

        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
    }

    public void UpdateGameBallsAliveUI(int _currentBallsAlive) => ballsAliveNumberText.text = "Game balls: " + _currentBallsAlive.ToString();

    public void UpdateBricksAliveUI(int _currentBricksAlive) => bricksLeftNumberText.text = "Bricks left: " + _currentBricksAlive.ToString();

    public void ShowMagneticBuffTimerUI(bool _show) => magneticBuffTimerText.enabled = _show;

    public void UpdateMagneticBuffTimerUI(float _time) => magneticBuffTimerText.text = "Buff timer: " + _time.ToString(format: "0.0");
}
