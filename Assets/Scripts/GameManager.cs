using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public Text highscoreText;

    private bool isPlaying = false;

    // Start is called before the first frame update
    void Start()
    {
        if (highscoreText != null)
            highscoreText.text = "Highscore - " + PlayerPrefs.GetInt("Highscore");
    }

    // Update is called once per frame
    void Update()
    {
        PlayMusic();   
    }

    public void PlayMusic()
    {
        if (!isPlaying)
        {
            if (SceneManager.GetActiveScene().buildIndex == 0)
                soundManagerScript.PlaySound("menu");
            else
                soundManagerScript.PlaySound("gamePlay");
            isPlaying = true;
        }
    }

    public void StartGame()
    {
        HighScore.setZero();
        soundManagerScript.PlaySound("buttonClick");
        SceneManager.LoadScene(1);
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        soundManagerScript.PlaySound("buttonClick");
        pauseMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        soundManagerScript.PlaySound("buttonClick");
        pauseMenu.SetActive(false);
    }

    public void EndGame()
    {
        soundManagerScript.PlaySound("buttonClick");
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        soundManagerScript.PlaySound("buttonClick");
        Application.Quit();
    }
}
