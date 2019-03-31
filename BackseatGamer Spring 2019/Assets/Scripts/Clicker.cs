using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicker : MonoBehaviour
{

    public Vector3 target;
    public bool atTarget;
    // Start is called before the first frame update
    void Start()
    {
        atTarget = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position,target) > .1f)
        {
            transform.position += (target - transform.position) / Vector3.Distance(transform.position, target) * Time.deltaTime;
            atTarget = true;
        }
    }

    public void newPoint(Vector3 point)
    {
        target = point;
    }
}
