using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    // singleton
    public static ScoreManager singleton;

    // text mesh pro
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    // score value
    public int score = 0;
    public int highScore = 0;

    private string scoreString = "SCORE : ";
    private string highScoreString = "HIGHSCORE : ";

    private void Start()
    {
        // set singleton
        singleton = this;

        setScoreUI();
    }

    void setScoreUI()
    {
        // get highscore value
        highScore = PlayerPrefs.GetInt("HighScore");

        // set score highscore UI
        scoreText.text = scoreString + "0";
        highScoreText.text = highScoreString + highScore.ToString();
    }

    // update scoretext UI
    void updateScoreUI(int value)
    {
        scoreText.text = scoreString + value.ToString();
    }

    public void updateScore()
    {
        if (highScore < score)
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }

    // increase score
    public void addScore()
    {
        score++;
        updateScoreUI(score);

        // increase obstacle move speed
        if(score % 5 ==0)
        {
            float currentSpeed = RunManager.singleton.obsSpeed;
            if (currentSpeed < 19)
                RunManager.singleton.obsSpeed += 2f;
        }
    }
}
