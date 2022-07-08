using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum RunState { START, RUNNING, PAUSE, END, WIN, LOSE }

public class RunManager : MonoBehaviour
{
    public static RunManager singleton;

    public RunState runState;

    private float obsDelay;
    public float obsSpeed;
    public float minDelay;
    public float maxDelay;

    public GameObject[] playerPrefabs;
    public Transform playerPos;
    private int playerIndex;

    public GameObject obsGO;
    public GameObject gameOverUI;
    public GameObject pauseUI;

    public Transform obsPos;
    public Transform endPos;

    private void Start()
    {
        singleton = this;
        setupScene();

        StartCoroutine(spawnObs());
    }

    private void Update()
    {
        togglePauseMenu();
        gameOverActions();
    }

    void setupScene()
    {
        runState = RunState.START;
        playerIndex = GameManager.singleton.getSelectedChar();

        spawnPlayer();
    }

    void spawnPlayer()
    {
        Instantiate(playerPrefabs[playerIndex], playerPos.position, Quaternion.identity);
        runState = RunState.RUNNING;
    }

    void togglePauseMenu()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (runState == RunState.RUNNING)
                enablePauseMenu();
            else
                disablePauseMenu();
        }
    }    

    void enablePauseMenu()
    {
        runState = RunState.PAUSE;
        pauseUI.SetActive(true);
        Time.timeScale = 0;
    }

    void disablePauseMenu()
    {
        runState = RunState.RUNNING;
        pauseUI.SetActive(false);
        Time.timeScale = 1;
    }

    void gameOverActions()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(runState == RunState.END)
            {
                // load RUN scene
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

                // unpause game
                Time.timeScale = 1;
            }
        }
    }

    public void gameOver()
    {
        runState = RunState.END;
        gameOverUI.SetActive(true);
        Time.timeScale = 0;
    }

    IEnumerator spawnObs()
    {
        obsDelay = Random.Range(minDelay, maxDelay);
        yield return new WaitForSeconds(obsDelay);
        Instantiate(obsGO, obsPos.position, Quaternion.identity);

        StartCoroutine(spawnObs());
    }
}
