using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum MainScreenState { MAIN, SELECTCHAR }

public class MainScreenManager : MonoBehaviour
{
    [SerializeField] private GameObject mainScreenPanel;
    [SerializeField] private GameObject charSelectPanel;

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
}
