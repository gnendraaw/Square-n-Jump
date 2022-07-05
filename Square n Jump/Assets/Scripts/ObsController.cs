using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsController : MonoBehaviour
{
    RunManager runManager;
    public Transform endPos;

    private void Start()
    {
        runManager = FindObjectOfType<RunManager>();
    }

    private void Update()
    {
        moveObs();
    }

    void moveObs()
    {
        transform.position += Vector3.left * runManager.obsSpeed * Time.deltaTime;

        if(transform.position.x <= runManager.endPos.position.x)
            Destroy(gameObject);
    }    
}
