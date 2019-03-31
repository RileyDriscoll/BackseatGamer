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
            
            transform.position += new Vector3(0, .1f*Mathf.Cos(Mathf.PI * jumpTime));
            jumpTime += Time.deltaTime*.75f;

            if (jumpTime >= 1)
            {
                transform.position += new Vector3(0, .1f * Mathf.Cos(Mathf.PI));
                jumpTime = 0;
                inJump = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            GetComponent<Animator>().Play("JMiniHurtAnimation");
        }
    }

    public void StartJump()
    {
        inJump = true;
    }
}
