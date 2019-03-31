using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonLevelManager : LevelManager
{
    public float cycleTime; //2.5
    public float cycleDistance; //0.0045
    public GameObject pumpHandle;

    private float timePassed;

    // Start is called before the first frame update
    void Start()
    {
        timePassed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        pumpHandle.transform.position += new Vector3(0, cycleDistance * (Mathf.Sin((Mathf.PI * .5f * timePassed))));
        timePassed += Time.deltaTime;
    }
}
