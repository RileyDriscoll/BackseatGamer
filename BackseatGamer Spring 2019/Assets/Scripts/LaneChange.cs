using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneChange : MonoBehaviour
{

    public float duration;
    private Vector3 startPos;
    //private GameObject car;
    private float timeElapsed;
    private float totalDeltaX;
    private bool changing;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (changing == true)
        {
            timeElapsed += Time.deltaTime;
            if (timeElapsed < duration)
            {
                transform.position = new Vector3(startPos.x + (totalDeltaX / timeElapsed), startPos.y, startPos.z);
            }
            else
            {
                changing = false;
            }
        }
    }

    public void StartChanging()
    {
        if (changing == false)
        {
            startPos = transform.position;
            if (startPos.x < 0)
            {
                totalDeltaX = 4;
            }
            else
            {
                totalDeltaX = -4;
            }
            changing = true;
            timeElapsed = .1F;
        }
    }
}
