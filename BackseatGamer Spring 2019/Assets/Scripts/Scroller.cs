using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour
{

    public GameObject[] sprites;
    public float speed;
    private enum Directions{up, down, left, right}
    public int direction;
    // Start is called before the first frame update
    void Start()
    {
        direction = 2;
    }

    // Update is called once per frame
    void Update()
    {
        float yMove = 0;
        float xMove = 0;

        if(direction == 2)
        {
            xMove = -1;
        }

        for(int i = 0; i < 3; i++)
        {
            sprites[i].transform.position = (new Vector3(sprites[i].transform.position.x + xMove * Time.deltaTime * speed,
                sprites[i].transform.position.y + yMove * Time.deltaTime * speed, 0));
            if(sprites[i].transform.position.x < -sprites[i].GetComponent<SpriteRenderer>().size.x)
            {
                int j = i + 2;
                if (j == 3) j = 0;
                if (j == 4) j = 1;

                sprites[i].transform.position = new Vector3(sprites[i].GetComponent<SpriteRenderer>().size.x + (sprites[i].transform.position.x + sprites[i].GetComponent<SpriteRenderer>().size.x),
                    sprites[i].transform.position.y, 0);
            }
        }
    }
}
