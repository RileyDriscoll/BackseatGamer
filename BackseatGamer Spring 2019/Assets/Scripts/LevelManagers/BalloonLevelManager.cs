using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonLevelManager : LevelManager
{
    public float cycleTime; //2.5
    public float cycleDistance; //0.0045
    public GameObject pumpHandle;
    public GameObject balloon;
    public float inflationRate;

    private float timePassed;
    private float currTime;
    private float fluctuation;
    private float threshold;

    // Start is called before the first frame update
    void Start()
    {
        timePassed = 0;
        currTime = 0;
        threshold = Random.Range(-5, 6);
    }

    // Update is called once per frame
    void Update()
    {
        currTime += Time.deltaTime;
        fluctuation = Random.Range(1, 10);
        if (balloon.transform.localScale.x + currTime*inflationRate/fluctuation > (1 + .02 * threshold)) 
        {
            balloon.transform.localScale = new Vector3(0, 0, 0);
            threshold = Random.Range(-5, 6);
        }
        balloon.transform.localScale += new Vector3(currTime*inflationRate/fluctuation, currTime*inflationRate/fluctuation);
        currTime = 0;
        pumpHandle.transform.position += new Vector3(0, cycleDistance * (Mathf.Sin((Mathf.PI * .5f * timePassed))));
        timePassed += Time.deltaTime;
    }
}
