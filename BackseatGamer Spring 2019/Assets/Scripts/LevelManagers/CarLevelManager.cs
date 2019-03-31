using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarLevelManager : LevelManager
{
    public LaneChange car;
    public SpikeGen leftLane;
    public SpikeGen rightLane;
    public float lastGen;
    public float spawnChance;
    public float altDelay;
    public float minDelay;
    public float maxDelay;
    public GameObject spikeA;
    public GameObject spikeB;
    public GameObject spikeC;
    private float timePassed;
    private bool lastWasLeft;
    private GameObject currSpike;
    private float weight;

    // Start is called before the first frame update
    void Start()
    {
        timePassed = 0;
        lastWasLeft = true;
        weight = 5;
        CoolGameManager.singleton.level = this;
        actionText = "Change";

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
            if (Random.Range(1, 101) <= spawnChance * Time.deltaTime * 2 || timePassed > maxDelay)
            {
                bool selected = false;
                while (selected != true)
                {
                    int debrisSelector = Random.Range(1, 4);
                    if (debrisSelector == 1 && currSpike != spikeA)
                    {
                        currSpike = spikeA;
                        selected = true;
                    }
                    else if (debrisSelector == 2 && currSpike != spikeB)
                    {
                        currSpike = spikeB;
                        selected = true;
                    }
                    else if (currSpike != spikeC)
                    {
                        currSpike = spikeC;
                        selected = true;
                    }
                }


                if (Random.Range(1, 11) <= weight)
                {
                    
                    if (timePassed < altDelay)
                    {
                        if (lastWasLeft == true)
                        {
                            leftLane.CreateInstance(currSpike.gameObject, new Vector3(leftLane.transform.position.x, leftLane.transform.position.y));
                            lastWasLeft = true;
                            timePassed = 0;
                            weight -= 1;
                        }
                        else
                        {
                            rightLane.CreateInstance(currSpike.gameObject, new Vector3(rightLane.transform.position.x, rightLane.transform.position.y));
                            lastWasLeft = false;
                            timePassed = 0;
                            weight += 1;
                        }
                    }
                    else
                    {
                        leftLane.CreateInstance(currSpike.gameObject, new Vector3(leftLane.transform.position.x, leftLane.transform.position.y));
                        lastWasLeft = true;
                        timePassed = 0;
                        weight -= 1;
                    }
                }
                else
                {
                    if (timePassed < altDelay)
                    {
                        if (lastWasLeft == true)
                        {
                            leftLane.CreateInstance(currSpike.gameObject, new Vector3(leftLane.transform.position.x, leftLane.transform.position.y));
                            lastWasLeft = true;
                            timePassed = 0;
                            weight -= 1;
                        }
                        else
                        {
                            rightLane.CreateInstance(currSpike.gameObject, new Vector3(rightLane.transform.position.x, rightLane.transform.position.y));
                            lastWasLeft = false;
                            timePassed = 0;
                            weight += 1;
                        }
                    }
                    else
                    {
                        rightLane.CreateInstance(currSpike.gameObject, new Vector3(rightLane.transform.position.x, rightLane.transform.position.y));
                        lastWasLeft = false;
                        timePassed = 0;
                        weight += 1;
                    }
                }
                
            }
            else
            {
                timePassed += Time.deltaTime;
            }
        }
        else
        {
            timePassed += Time.deltaTime;
        }
    }
    public override void StartAction()
    {
        car.StartChanging();
    }
}
