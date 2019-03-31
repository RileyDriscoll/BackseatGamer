using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonLevelManager : LevelManager
{
    public float cycleTime; //2.5
    public float cycleDistance; //0.0045
    public GameObject pumpHandle;
    public GameObject balloon;
    public AudioClip pop;
    public AudioClip whistle;
    public AudioClip cheer;
    public AudioClip boo;
    public AudioClip close;
    public float inflationRate;
    private bool playClose;

    private float timePassed;
    private float currTime;
    private float fluctuation;
    private float threshold;
    private bool stop;
    private bool inRoutine;

    // Start is called before the first frame update
    void Start()
    {
        CoolGameManager.singleton.level = this;
        actionText = "DudeStop";
        timePassed = 0;
        currTime = 0;
        threshold = Random.Range(-5, 0);
        winStatus = true;
        stop = false;
        playClose = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GetComponent<AudioSource>().isPlaying || gameOver == true)
        {
            gameOver = true;
        }
        else
        {
            currTime += Time.deltaTime;
            fluctuation = Random.Range(1, 10);
            balloon.transform.localScale += new Vector3(currTime * inflationRate / fluctuation, currTime * inflationRate / fluctuation);
            currTime = 0;
            pumpHandle.transform.position += new Vector3(0, cycleDistance * (Mathf.Sin((Mathf.PI * .5f * timePassed))));
            timePassed += Time.deltaTime;
            if (stop)
            {
                if((1 + .02 * threshold) - (balloon.transform.localScale.x + currTime * inflationRate / fluctuation) < .2){
                    if (!inRoutine)
                    {
                        inRoutine = true;
                        StartCoroutine(winSeq());
                    }
                }
                else
                {
                    if (!inRoutine)
                    {
                        inRoutine = true;
                        StartCoroutine(failSeq());
                    }
                }
            }
            if ((1 + .02 * threshold) - (balloon.transform.localScale.x + currTime * inflationRate / fluctuation) < .3)
            {
                if (playClose)
                {
                    playClose = false;
                    GetComponent<AudioSource>().PlayOneShot(close);
                }
            }
            if (balloon.transform.localScale.x + currTime * inflationRate / fluctuation > (1 + .02 * threshold) && !inRoutine)
            {
                balloon.transform.localScale = new Vector3(0, 0, 0);
                winStatus = false;
                gameOver = true;
                threshold = Random.Range(-5, 6);
                GetComponent<AudioSource>().PlayOneShot(pop);
            }
        }
    }

    public override void StartAction()
    {
        stop = true;
    }

    private IEnumerator failSeq()
    {
        float timer = 0;
        GetComponent<AudioSource>().PlayOneShot(boo);
        while (timer < 1f)
        {
            balloon.transform.position += new Vector3(0.01f, -.05f, 0);
            timer += Time.deltaTime;
            yield return new WaitForSeconds(.01f);
        }
        gameOver = true;
        winStatus = false;
        yield break;
    }

    private IEnumerator winSeq()
    {
        float timer = 0;
        GetComponent<AudioSource>().PlayOneShot(cheer);
        GetComponent<AudioSource>().PlayOneShot(whistle);
        
        while (timer < .2f)
        {
            timer += Time.deltaTime;
            yield return new WaitForSeconds(.1f);
        }

        balloon.transform.localScale = new Vector3(0, 0, 0);
        stop = false;
        timePassed = 0;
        threshold = Random.Range(-5, 6);
        inRoutine = false;
        playClose = true;
        yield break;
    }
}
