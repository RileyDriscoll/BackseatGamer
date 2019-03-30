using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarLevelManager : LevelManager
{
    public SpikeGen leftLane;
    public SpikeGen rightLane;
    public float lastGen;
    public float spawnChance;
    public float altDelay;
    public float minDelay;
    public GameObject spike;
    private float timePassed;
    private bool lastWasLeft;

    // Start is called before the first frame update
    void Start()
    {
        timePassed = 0;
        leftLane.CreateInstance(spike.gameObject, new Vector3(leftLane.transform.position.x, leftLane.transform.position.y));
        lastWasLeft = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (timePassed > minDelay)
        {
            if (Random.Range(1, 101) <= spawnChance * Time.deltaTime * 2)
            {
                if (Random.Range(1, 101) <= 50)
                {
                    if (timePassed < altDelay)
                    {
                        if (lastWasLeft == true)
                        {
                            leftLane.CreateInstance(spike.gameObject, new Vector3(leftLane.transform.position.x, leftLane.transform.position.y));
                            lastWasLeft = true;
                            timePassed = 0;
                            //rightLane.CreateInstance(spike.gameObject, new Vector3(rightLane.transform.position.x, rightLane.transform.position.y));
                        }
                        else
                        {
                            rightLane.CreateInstance(spike.gameObject, new Vector3(rightLane.transform.position.x, rightLane.transform.position.y));
                            lastWasLeft = false;
                            timePassed = 0;
                        }
                    }
                    else
                    {
                        leftLane.CreateInstance(spike.gameObject, new Vector3(leftLane.transform.position.x, leftLane.transform.position.y));
                        lastWasLeft = true;
                        timePassed = 0;
                    }
                }
                else
                {
                    if (timePassed < altDelay)
                    {
                        if (lastWasLeft == true)
                        {
                            leftLane.CreateInstance(spike.gameObject, new Vector3(leftLane.transform.position.x, leftLane.transform.position.y));
                            lastWasLeft = true;
                            timePassed = 0;
                        }
                        else
                        {
                            rightLane.CreateInstance(spike.gameObject, new Vector3(rightLane.transform.position.x, rightLane.transform.position.y));
                            lastWasLeft = false;
                            timePassed = 0;
                        }
                    }
                    else
                    {
                        rightLane.CreateInstance(spike.gameObject, new Vector3(rightLane.transform.position.x, rightLane.transform.position.y));
                        lastWasLeft = false;
                        timePassed = 0;
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
}
