using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{

    public GameObject playerBox;
    public GameObject johnBoxR;
    public GameObject johnBoxL;
    public Transform john;

    public GameObject CreateDialogue(string text, int person)
    {
        GameObject diaBox = null;
        if (person == 0) {
            diaBox = GetComponent<SpikeGen>().CreateInstance(playerBox, new Vector3(11 - playerBox.GetComponent<SpriteRenderer>().size.x,
                -4.5f + playerBox.GetComponent<SpriteRenderer>().size.y));
        }

        if(person == 1)
        {
            float leftright = 0;
            if(Random.Range(0,2) == 0)
            {
                leftright = johnBoxL.GetComponent<SpriteRenderer>().size.x;
                diaBox = GetComponent<SpikeGen>().CreateInstance(johnBoxL, new Vector3(john.transform.position.x - leftright,
                john.position.y + 2));
            }
            else
            {
                leftright = -johnBoxR.GetComponent<SpriteRenderer>().size.x;
                diaBox = GetComponent<SpikeGen>().CreateInstance(johnBoxR, new Vector3(john.transform.position.x - leftright,
                john.position.y + 3));
            }
            
            diaBox.GetComponent<CharacterParallax>().defaultPos = new Vector3(-leftright, 0.5f);

        }


        return diaBox;
    }
}
