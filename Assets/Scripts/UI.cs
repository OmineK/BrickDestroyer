using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] GameObject darkScreen;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] GameObject levelCompleteScreen;
    [SerializeField] GameObject pauseScreen;

    void Start()
    {
        darkScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        levelCompleteScreen.SetActive(false);
        pauseScreen.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void UnpauseGame()
    {
        Time.timeScale = 1;

        pauseScreen.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

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

    public void LevelComplete()
    {
        levelCompleteScreen.SetActive(true);
        Invoke(nameof(LoadNextScene), 3f);
    }

    void LoadNextScene()
    {
        Time.timeScale = 1;

        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
    }
}
