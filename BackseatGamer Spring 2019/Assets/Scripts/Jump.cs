using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{

    private Vector3 startPos;
    private bool inJump;
    private float jumpTime;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        inJump = false;
        jumpTime = 0;
    }

    // Update is called once per frame
    void Update()
    {

        
        if (inJump)
        {
            
            transform.position = new Vector3(startPos.x, startPos.y + 2*Mathf.Sin(Mathf.PI * jumpTime));
            jumpTime += Time.deltaTime*.75f;

            if (jumpTime >= 1)
            {
                transform.position = startPos;
                jumpTime = 0;
                inJump = false;
            }
        }
    }

    public void StartJump()
    {
        inJump = true;
    }
}
