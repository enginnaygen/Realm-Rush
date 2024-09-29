using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{

    [SerializeField] bool isPlacable;
    [SerializeField] GameObject balista;

    private void OnMouseDown()
    {
        if(isPlacable)
        {
            Instantiate(balista, transform.position, Quaternion.identity);
            isPlacable = false;

        }

    }

}
