using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum RunState { START, RUNNING, PAUSE, END, WIN, LOSE }

public class RunManager : MonoBehaviour
{
    // singleton
    public static RunManager singleton;

    // game state
    public RunState runState;

    // obstacle move speed
    public float obsSpeed;

    // obstacle spawn delay
    private float obsDelay;
    public float minDelay;
    public float maxDelay;

    // obstacle spawn point
    public Transform obsPos;

    // obstacle end point
    public Transform endPos;

    // obstacle gameobject
    public GameObject obsGO;

    // gameover UI
    public GameObject gameOverUI;

    private void Start()
    {
        // set singleton
        singleton = this;

        runState = RunState.START;
        runState = RunState.RUNNING;
        StartCoroutine(spawnObs());
    }

    private void Update()
    {
        gameOverActions();
    }

    // some actions that could be perform if game over
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

    // set gameover state if the game ends
    public void gameOver()
    {
        runState = RunState.END;

        // set gameover ui to active
        gameOverUI.SetActive(true);

        // pause the game
        Time.timeScale = 0;
    }

    IEnumerator spawnObs()
    {
        // wait 2 seconds before spawning obstacle
        obsDelay = Random.Range(minDelay, maxDelay);
        yield return new WaitForSeconds(obsDelay);

        Instantiate(obsGO, obsPos.position, Quaternion.identity);
        StartCoroutine(spawnObs());
    }
}
