using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager singleton;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    public int score = 0;
    public int highScore = 0;

    private string scoreString = "SCORE : ";
    private string highScoreString = "HIGHSCORE : ";

    private void Start()
    {
        singleton = this;
        setScoreUI();
    }

    void setScoreUI()
    {
        highScore = PlayerPrefs.GetInt("HighScore");
        scoreText.text = scoreString + "0";
        highScoreText.text = highScoreString + highScore.ToString();
    }

    // update scoretext UI
    void updateScoreUI()
    {
        scoreText.text = scoreString + score.ToString();
    }

    void increaseObsSpeed()
    {
        float currentSpeed = RunManager.singleton.obsSpeed;
        if(currentSpeed % 5 == 0 && currentSpeed < 13)
            RunManager.singleton.obsSpeed += 2f;
    }

    public void updateScore()
    {
        if (highScore < score)
            PlayerPrefs.SetInt("HighScore", score);
    }

    // increase score
    public void addScore()
    {
        score++;
        updateScoreUI();
        increaseObsSpeed();
    }
}
