using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public float timeToFailure;
    // Start is called before the first frame update
    void Start()
    {
        CoolGameManager.singleton.level = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartAction()
    {

    }
}
