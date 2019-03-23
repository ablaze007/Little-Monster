using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public Text highscoreText;

    // Start is called before the first frame update
    void Start()
    {
        if (highscoreText != null)
            highscoreText.text = "Highscore - " + PlayerPrefs.GetInt("Highscore");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        Debug.Log("Starting game");
        HighScore.setZero();
        SceneManager.LoadScene(1);
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }

    public void EndGame()
    {
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
