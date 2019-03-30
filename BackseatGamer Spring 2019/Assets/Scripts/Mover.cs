using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{

    public int direction;
    public float speed;
    public float timePassed;
    public float destroyTime;
    private enum Directions { up, down, left, right };

    // Update is called once per frame
    void Update()
    {
        int xMove = 0;
        int yMove = 0;

        if(direction == 0)
        {
            yMove = 1;
        }
        if (direction == 1)
        {
            yMove = -1;
        }
        if (direction == 2)
        {
            yMove = -1;
        }
        if (direction == 3)
        {
            yMove = 1;
        }

        if (timePassed >= destroyTime)
        {
            Destroy(this.gameObject);
        }

        transform.position = (new Vector3(transform.position.x + xMove * Time.deltaTime * speed,
                transform.position.y + yMove * Time.deltaTime * speed, 0));

        timePassed += Time.deltaTime;
    }
}
