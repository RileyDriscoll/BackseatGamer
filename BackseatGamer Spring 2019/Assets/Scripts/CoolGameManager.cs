using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoolGameManager : MonoBehaviour
{

    public DialogueManager dialogue;
    public LevelManager level;
    public GameObject angerBar;
    public GameObject angerFace;
    public GameObject john;
    public Sprite[] johnEmotions;
    public GameObject[] miniGames;
    public bool startUp;

    public GameObject currentGame;
    public int lastGame;
    private float anger;
    private int wins;

    public static CoolGameManager singleton;

    private void Awake()
    {
        if(singleton == null)
        {
            singleton = this;
        }
        else
        {
            Destroy(this);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        wins = 0;
        anger = 10;
        if (startUp)
        {
            currentGame = Instantiate(miniGames[2], new Vector3(), Quaternion.identity);
        }
        lastGame = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (anger <= 0)
        {
            anger = 0;
        }
        else if(anger != 100)
        {
            if (level != null)
            {
                anger -= Time.deltaTime * 1.5f;
            }
            else
            {
                anger -= Time.deltaTime;
            }
        }
        handleAnger();

        angerBar.transform.localPosition = new Vector3(0, (anger / 100)*5.65f, 0);

        if(level != null)
        {
            handleLevel();
        }

        if (Input.GetButtonDown("Jump"))
        {
            anger += 10;

            if(level == null)
            {
                dialogue.CreateDialogue("Jump", 0);
                dialogue.CreateDialogue("LevelStarted", 1);
                
            }
            else
            {
                dialogue.CreateDialogue(level.actionText, 0);
                if (anger >= 32 && Random.Range(1,101) > 30)
                {
                    dialogue.CreateDialogue("StopTellin", 1);
                }
                level.StartAction();
            }
            
        }
    }

    private void handleLevel()
    {
        if (level.gameOver)
        {
            if (level.winStatus)
            {
                anger -= 15;
                showWin();
            }
            else
            {
                anger += 25;
                showLoss();
            }

            level = null;
        }
    }

    private void handleAnger()
    {
        if (anger < 32)
        {
            angerFace.GetComponent<Animator>().Play("NeutalFaceAnimation");
            john.GetComponent<SpriteRenderer>().sprite = johnEmotions[0];
        }
        else if (anger >= 32 && anger < 65)
        {
            angerFace.GetComponent<Animator>().Play("OrangeFaceAnimation");
            john.GetComponent<SpriteRenderer>().sprite = johnEmotions[1];
        }
        else if (anger >= 65 && anger < 100)
        {
            if(Random.Range(1,1001) > 995)
            {
                randomJohnDia();
            }
            angerFace.GetComponent<Animator>().Play("RedFaceAnimation");
            john.GetComponent<SpriteRenderer>().sprite = johnEmotions[2];
        }
        else
        {
            anger = 100;
            john.GetComponent<SpriteRenderer>().sprite = johnEmotions[3];
        }
    }

    private void randomJohnDia()
    {
        string[] words = { "Bro", "FuckYou", "Jeeze", "OneMoreWord", "AUG" };
        dialogue.CreateDialogue(words[Random.Range(0,words.Length)], 1);
    }

    private void showWin()
    {
        Destroy(currentGame);
        currentGame = Instantiate(miniGames[0], new Vector3(), Quaternion.identity);
        StartCoroutine(waitToChangeWin());
    }

    private void showLoss()
    {
        StartCoroutine(waitToChangeLoss());
    }

    private IEnumerator waitToChangeWin()
    {
        yield return new WaitForSeconds(2);
        Destroy(currentGame);
        int rand = Random.Range(2, 6);
        while(rand == lastGame)
        {
            rand = Random.Range(2, 6);
        }
        currentGame = Instantiate(miniGames[rand], new Vector3(), Quaternion.identity);
        lastGame = rand;
        wins += 1;
        yield break;
    }

    private IEnumerator waitToChangeLoss()
    {
        yield return new WaitForSeconds(1);
        Destroy(currentGame);
        currentGame = Instantiate(miniGames[1], new Vector3(), Quaternion.identity);
        yield return new WaitForSeconds(2);
        Destroy(currentGame);
        int rand = Random.Range(2, 6);
        while (rand == lastGame)
        {
            rand = Random.Range(2, 6);
        }
        currentGame = Instantiate(miniGames[rand], new Vector3(), Quaternion.identity);
        lastGame = rand;
        yield break;
    }
}
