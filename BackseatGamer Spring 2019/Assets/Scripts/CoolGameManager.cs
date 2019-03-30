using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoolGameManager : MonoBehaviour
{

    public DialogueManager dialogue;
    public LevelManager level;

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
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Jump"))
        {
            if(level == null)
            {
                dialogue.CreateDialogue("Fuck You", 0);
                dialogue.CreateDialogue("Fuck You", 1);
            }
            else
            {
                level.StartAction();
            }
            
        }
    }
}
