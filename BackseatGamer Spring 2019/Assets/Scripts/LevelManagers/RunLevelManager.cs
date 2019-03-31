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
        CoolGameManager.singleton.level = this;
        actionText = "Jump";
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GetComponent<AudioSource>().isPlaying)
        {
            winStatus = true;
            gameOver = true;
        }
        if (timePassed > minDelay)
        {
            if (Random.Range(1, 101) <= spwanChance * Time.deltaTime * 2)
            {
                spikeGen.CreateInstance(spike.gameObject, new Vector3(spikeGen.transform.position.x, 
                    spikeGen.transform.position.y,spikeGen.transform.position.z));
                timePassed = 0;
            }
        }
        else
        {
            timePassed += Time.deltaTime;
        }
    }

    public override void StartAction()
    {
        jump.StartJump();
    }

    
}
