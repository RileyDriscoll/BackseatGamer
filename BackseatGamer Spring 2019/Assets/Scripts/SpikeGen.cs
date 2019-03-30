using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeGen : MonoBehaviour
{
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
            if (Random.Range(1, 101) <= spwanChance * Time.deltaTime*2)
            {
                CreateInstance(spike.gameObject, new Vector3(this.transform.position.x, this.transform.position.y));
                timePassed = 0;
            }
        }
        else
        {
            timePassed += Time.deltaTime;
        }
    }

    public GameObject CreateInstance(GameObject obj, Vector3 pos)
    {
        return Instantiate(obj, pos, Quaternion.identity);
    }
}
