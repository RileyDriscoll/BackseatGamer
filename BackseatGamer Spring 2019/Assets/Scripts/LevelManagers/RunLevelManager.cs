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
    private Queue<GameObject> spikes;
    private GameObject curSpike;
    private float timePassed;
    public GameObject spike;
    // Start is called before the first frame update
    void Start()
    {
        timePassed = 0;
        CoolGameManager.singleton.level = this;
        actionText = "Jump";
        spikes = new Queue<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (curSpike == null)
        {
            if (!(spikes.Count == 0))
            {
                curSpike = spikes.Dequeue();
            }
        }
        if (curSpike != null)
        {
            if (Vector3.Distance(jump.transform.position, curSpike.transform.position) < .1f)
            {
                curSpike = null;
            }
            else if (Vector3.Distance(jump.transform.position, curSpike.transform.position) < 6f)
            {
                if (Random.Range(0, 101) > 98)
                {
                    StartAction();
                    curSpike = null;
                }
            }
        }
        
        if (!GetComponent<AudioSource>().isPlaying)
        {
            winStatus = true;
            gameOver = true;
        }
        if (timePassed > minDelay)
        {
            if (Random.Range(1, 101) <= spwanChance * Time.deltaTime * 2)
            {
                spikes.Enqueue(spikeGen.CreateInstance(spike.gameObject, new Vector3(spikeGen.transform.position.x, 
                    spikeGen.transform.position.y,spikeGen.transform.position.z)));
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
