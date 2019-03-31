using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public float timeToFailure;
    public string actionText;
    public bool gameOver;
    public bool winStatus;
    // Start is called before the first frame update
    void Start()
    {
        CoolGameManager.singleton.level = this;
        actionText = "FuckYou";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void StartAction()
    {

    }
}
