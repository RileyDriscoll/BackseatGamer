using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{

    public GameObject playerBox;
    public GameObject johnBox;
    public Transform john;

    public GameObject CreateDialogue(string text, int person)
    {
        GameObject diaBox = null;
        if (person == 0) {
            diaBox = GetComponent<SpikeGen>().CreateInstance(playerBox, new Vector3(Screen.width / 2 - playerBox.GetComponent<SpriteRenderer>().size.x,
                -Screen.height/2 - playerBox.GetComponent<SpriteRenderer>().size.y));
        }

        if(person == 1)
        {
            float leftright = 0;
            if(Random.Range(0,2) == 0)
            {
                leftright = johnBox.GetComponent<SpriteRenderer>().size.x/2;
            }
            else
            {
                leftright = -johnBox.GetComponent<SpriteRenderer>().size.x;
            }
            diaBox = GetComponent<SpikeGen>().CreateInstance(johnBox, new Vector3(john.transform.position.x - leftright,
                john.position.y));
        }


        return diaBox;
    }
}
