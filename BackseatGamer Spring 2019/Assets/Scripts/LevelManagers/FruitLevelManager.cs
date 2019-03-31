using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitLevelManager : LevelManager
{

    public Clicker click;
    public Transform[] pointArray;
    public int prevPoint;
    public int correctPoint;
    public Animator fruit;
    // Start is called before the first frame update
    void Start()
    {
        CoolGameManager.singleton.level = this;
        actionText = "NotThatOne";
        prevPoint = 3;
        correctPoint = Random.Range(0, 3);
        if(correctPoint == 0)
        {
            fruit.Play("AppleAnimation");
        }else if(correctPoint == 1)
        {
            fruit.Play("BananaAnimation");
        }else
        {
            fruit.Play("OrangeAnimation");
        }
    }

    // Update is called once per frame
    void Update()
    {
        click.newPoint(pointArray[prevPoint].position);
        if (!GetComponent<AudioSource>().isPlaying)
        {
            gameOver = true;
            if (Vector3.Distance(click.transform.position, pointArray[correctPoint].position) > 1)
            {
                winStatus = false;
            }
            else
            {
                winStatus = true;
            }
        }

        if(Random.Range(1,1001) > 995)
        {
            StartAction();
        }
    }

    public override void StartAction()
    {
        click.newPoint(RandomNewPoint());
    }

    private Vector3 RandomNewPoint()
    {
        int rand = Random.Range(0, 4);
        while(rand == prevPoint)
        {
            rand = Random.Range(0, 4);
        }
        prevPoint = rand;
        return pointArray[rand].position;
    }
}
