using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseLevel : MonoBehaviour
{
    public LevelManager level;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            level.winStatus = false;
            level.gameOver = true;
        }
    }
    
}
