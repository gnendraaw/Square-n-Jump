using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsController : MonoBehaviour
{
    // RunManager script
    RunManager runManager;

    // end position
    public Transform endPos;

    private void Start()
    {
        runManager = FindObjectOfType<RunManager>();
    }

    private void Update()
    {
        moveObs();
    }

    // move the obstacle
    void moveObs()
    {
        // moving the obstacle
        transform.position += Vector3.left * runManager.obsSpeed * Time.deltaTime;

        // destroy obstacle if it reachs endPos
        if(transform.position.x <= runManager.endPos.position.x)
        {
            Destroy(gameObject);
        }
    }    
}
