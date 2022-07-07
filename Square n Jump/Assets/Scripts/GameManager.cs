using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager singleton;

    private void Start()
    {
        singleton = this;
    }

    public void setSelectedChar()
    {

    }

    public int getSelectedChar()
    {
        return PlayerPrefs.GetInt("SelectedChar");
    }
}
