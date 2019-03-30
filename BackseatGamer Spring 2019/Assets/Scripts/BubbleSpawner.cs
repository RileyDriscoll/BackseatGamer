using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{
    public float x;
    public float y;
    public Sprite style;
    public string content;

    public GameObject bubblePreFab;

    private float duration;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void BuildABubble ()
    {
        GameObject = theBubble;
        theBubble = Instantiate(bubblePreFab);
        theBubble
    }

}
