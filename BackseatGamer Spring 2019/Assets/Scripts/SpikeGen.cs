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
            if (Random.Range(1, 100) <= spwanChance)
            {
                Instantiate(spike.gameObject, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity);
                timePassed = 0;
            }
        }
        else
        {
            timePassed += Time.deltaTime;
        }
    }
}
