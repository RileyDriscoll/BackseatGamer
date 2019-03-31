using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class SortByY : MonoBehaviour
{

    private float topMaxPosition = 300;

    // Update is called once per frame
    void LateUpdate()
    {
        this.GetComponent<SortingGroup>().sortingOrder = Mathf.RoundToInt(topMaxPosition - transform.position.y);
    }
}
