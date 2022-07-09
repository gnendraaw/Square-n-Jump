using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager singleton;

    private int playerPoint;

    private void Start()
    {
        setup();
    }

    void setup()
    {
        singleton = this;
        setPlayerPoint(PlayerPrefs.GetInt("PlayerPoint"));
    }

    public void setPlayerPoint(int value)
    {
        playerPoint = value;
    }

    public int getPlayerPoint()
    {
        return playerPoint;
    }
        
    public void addPoint()
    {
        setPlayerPoint(getPlayerPoint() + 1);
    }

    public void savePlayerPoint()
    {
        PlayerPrefs.SetInt("PlayerPoint", getPlayerPoint());
    }
        
    public int getSelectedChar()
    {
        return PlayerPrefs.GetInt("SelectedChar");
    }
}
