using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum MainScreenState { MAIN, SELECTCHAR }

public class MainScreenManager : MonoBehaviour
{
    [SerializeField] private GameObject mainScreenPanel;
    [SerializeField] private GameObject charSelectPanel;
    [SerializeField] private bool isCharSelected = false;

    public MainScreenState mainScreenState;

    private bool isSelectingChar = false;

    private void Start()
    {
        mainScreenState = MainScreenState.MAIN;
    }

    private void Update()
    {
        toggleCharSelect();
    }

    void toggleCharSelect()
    {
        if(!isSelectingChar)
            enableCharSelect();
        else
            disableCharSelect();
    }

    void disableCharSelect()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            isSelectingChar = false;
            mainScreenState = MainScreenState.MAIN;
            charSelectPanel.SetActive(false);
            mainScreenPanel.SetActive(true);
        }
    }

    void enableCharSelect()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            isSelectingChar = true;
            mainScreenState = MainScreenState.SELECTCHAR;
            charSelectPanel.SetActive(true);
            mainScreenPanel.SetActive(false);
        }
    }

    public void startRun()
    {
        // load run scene
        if(isCharSelected)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void selectChar(int index)
    {
        isCharSelected = true;
        PlayerPrefs.SetInt("SelectedChar", index);
    }
}
