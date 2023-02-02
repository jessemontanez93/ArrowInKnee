using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    private int score;
    public TextMeshProUGUI scoreText;
    public int sessionscore;
    public TextMeshProUGUI bestScore;
    private float timer;
    public GameObject player;

    private void Awake()
    {
        score = 0;
        scoreText.text = score.ToString();
        Application.targetFrameRate = 60;
        Time.timeScale = 1f;
        UpdateHighsScore();
        

    }

    void Update()
    {
        if(player != null)
        {
            timer += Time.deltaTime;

            if (timer > 5f)
            {
                score += 5;

                //We only need to update the text if the score changed.
                scoreText.text = score.ToString();

                //Reset the timer to 0.
                timer = 0;
            }

            CheckHighScore();
        }
    }

    void CheckHighScore()
    {
        if(score > PlayerPrefs.GetInt("Best", 0))
        {
            PlayerPrefs.SetInt("Best", score);
            UpdateHighsScore();
        }
    }

    void UpdateHighsScore()
    {
        bestScore.text = $"Best: {PlayerPrefs.GetInt("Best", 0)}";
    }

}
