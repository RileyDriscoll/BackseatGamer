using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneChange : MonoBehaviour
{

    public float duration;
    //private GameObject car;
    private float timeElapsed;
    private float totalDeltaX;
    private bool changing;
    private bool rightLane;

    // Start is called before the first frame update
    void Start()
    {
        rightLane = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (changing == true)
        {
            timeElapsed += Time.deltaTime;
            if (timeElapsed < duration)
            {
                transform.position += new Vector3(totalDeltaX * Time.deltaTime, 0, 0);
            }
            else
            {
                changing = false;
                timeElapsed = 0;
            }
        }
    }

    public void StartChanging()
    {
        if (changing == false)
        {
            
            if (rightLane)
            {
                totalDeltaX = -8;
                rightLane = false;
            }
            else
            {
                totalDeltaX = 8;
                rightLane = true;
            }
            changing = true;
            timeElapsed = 0;
        }
    }
}
