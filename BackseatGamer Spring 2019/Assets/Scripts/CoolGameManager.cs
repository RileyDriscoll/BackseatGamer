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
        if(singleton != null)
        {
            singleton = this;
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
        if (anger < 32)
        {
            angerFace.GetComponent<Animator>().Play("NeutalFaceAnimation");
            john.GetComponent<SpriteRenderer>().sprite = johnEmotions[0];
        } else if (anger >= 32 && anger < 65)
        {
            angerFace.GetComponent<Animator>().Play("OrangeFaceAnimation");
            john.GetComponent<SpriteRenderer>().sprite = johnEmotions[1];
        } else if (anger >= 65 && anger < 100)
        {
            angerFace.GetComponent<Animator>().Play("RedFaceAnimation");
            john.GetComponent<SpriteRenderer>().sprite = johnEmotions[2];
        } else
        {
            anger = 100;
            john.GetComponent<SpriteRenderer>().sprite = johnEmotions[3];
        }

        angerBar.transform.localPosition = new Vector3(0, (anger / 100)*5.65f, 0);

        if (Input.GetButtonDown("Jump"))
        {
            anger += 10;
            if(level == null)
            {
                dialogue.CreateDialogue("FuckYou", 0);
                dialogue.CreateDialogue("FuckYou", 1);
                
            }
            else
            {
                level.StartAction();
            }
            
        }
    }
}
