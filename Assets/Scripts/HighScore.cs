using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    private static HighScore _instance;

    public static HighScore Instance
    {
        get
        {
            if (_instance == null)
            {
                //UIManager is null
            }
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    public static int currentScore;

    // Start is called before the first frame update
    void Start()
    {
        currentScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void UpdateScore()
    {
        if (currentScore > PlayerPrefs.GetInt("Highscore", 0))
            PlayerPrefs.SetInt("Highscore", currentScore);
    }

    public static void AddScore()
    {
        currentScore++;
    }

    public static int GetScore()
    {
        return currentScore;
    }

    public static void setZero()
    {
        currentScore = 0;
    }
}
