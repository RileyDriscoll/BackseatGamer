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

    private float anger;

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
        anger = 80;
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
            anger -= Time.deltaTime*5;
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
                if (anger >= 32)
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
            if(Random.Range(1,101) > 99)
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

    }

    private void showLoss()
    {

    }
}
