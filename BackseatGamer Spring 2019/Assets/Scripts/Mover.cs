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
            xMove = -1;
        }
        if (direction == 3)
        {
            xMove = 1;
        }

        if (timePassed >= destroyTime)
        {
            Destroy(this.gameObject);
        }

        if (GetComponent<CharacterParallax>() != null)
        {
            GetComponent<CharacterParallax>().defaultPos += (new Vector3(xMove * Time.deltaTime * speed,
                    yMove * Time.deltaTime * speed, 0));
            GetComponent<CharacterParallax>().charPos += (new Vector3(xMove * Time.deltaTime * speed,
                    yMove * Time.deltaTime * speed, 0));
        }
        else
        {
            transform.position = (new Vector3(transform.position.x + xMove * Time.deltaTime * speed,
                    transform.position.y + yMove * Time.deltaTime * speed, 0));
        }

        timePassed += Time.deltaTime;
    }
}
