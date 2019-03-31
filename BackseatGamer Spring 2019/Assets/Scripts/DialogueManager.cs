using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{

    public GameObject playerBox;
    public GameObject johnBoxR;
    public GameObject johnBoxL;
    public Transform john;

    public Dictionary<string, GameObject> wordTable;

    public string[] words;
    public GameObject[] texts;



    private void Start()
    {

        wordTable = new Dictionary<string, GameObject>();
        for(int i = 0; i < words.Length; i++)
        {
            wordTable.Add(words[i], texts[i]);
        }
    }

    public GameObject CreateDialogue(string text, int person)
    {
        GameObject diaBox = null;
        if (person == 0) {
            diaBox = GetComponent<SpikeGen>().CreateInstance(playerBox, new Vector3(11 - playerBox.GetComponent<SpriteRenderer>().size.x,
                -6f + playerBox.GetComponent<SpriteRenderer>().size.y,-1));
        }

        if(person == 1)
        {
            float leftright = 0;
            if(Random.Range(0,2) == 0)
            {
                leftright = johnBoxL.GetComponent<SpriteRenderer>().size.x;
                diaBox = GetComponent<SpikeGen>().CreateInstance(johnBoxL, new Vector3(john.transform.position.x - leftright,
                john.position.y + 2,-3));
            }
            else
            {
                leftright = -johnBoxR.GetComponent<SpriteRenderer>().size.x;
                diaBox = GetComponent<SpikeGen>().CreateInstance(johnBoxR, new Vector3(john.transform.position.x - leftright,
                john.position.y + 3,-3));
            }
            
            diaBox.GetComponent<CharacterParallax>().defaultPos = new Vector3(-leftright, 0.5f);

        }

        GameObject textObj = GetComponent<SpikeGen>().CreateInstance(wordTable[text], new Vector3(diaBox.transform.position.x,
                diaBox.transform.position.y));
        textObj.transform.parent = diaBox.transform;
        textObj.transform.position += new Vector3(0, 0, diaBox.transform.position.z - 1);
        
        

        return diaBox;
    }
}
