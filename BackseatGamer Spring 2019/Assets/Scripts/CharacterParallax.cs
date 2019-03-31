using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterParallax : MonoBehaviour
{

    public Vector3 defaultPos;
    public Vector3 charPos;
    public bool alreadySet;
    private Vector3 mouseDefault;
    public float scaler;
    // Start is called before the first frame update
    void Start()
    {
        if(scaler == 0)
        {
            scaler = 1;
        }
        charPos = this.transform.position;
        if (!alreadySet)
        {
            defaultPos = this.transform.position;
        }
        mouseDefault = Input.mousePosition;
        

    }

    // Update is called once per frame
    void LateUpdate()
    {
        charPos.x -= (Input.mousePosition.x - mouseDefault.x)*.01f*scaler;
        charPos.x = Mathf.Max(Mathf.Min(charPos.x, defaultPos.x + 3*scaler), defaultPos.x + -3*scaler);

        charPos.y -= (Input.mousePosition.y - mouseDefault.y) * .01f*scaler;
        charPos.y = Mathf.Max(Mathf.Min(charPos.y, defaultPos.y + 1*scaler), defaultPos.y - 1*scaler);

        

        mouseDefault = Input.mousePosition;
        this.transform.position = charPos;
    }
}
