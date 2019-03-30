using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunLevelManager : LevelManager
{

    public Jump jump;
    public SpikeGen spikeGen;
    public float lastGen;
    public float spwanChance;
    public float minDelay;
    private float timePassed;
    public GameObject spike;
    // Start is called before the first frame update
    void Start()
    {
        timePassed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (timePassed > minDelay)
        {
            if (Random.Range(1, 101) <= spwanChance * Time.deltaTime * 2)
            {
                spikeGen.CreateInstance(spike.gameObject, new Vector3(spikeGen.transform.position.x, spikeGen.transform.position.y));
                timePassed = 0;
            }
        }
        else
        {
            timePassed += Time.deltaTime;
        }
    }

    public new void StartAction()
    {
        jump.StartJump();
    }
}
