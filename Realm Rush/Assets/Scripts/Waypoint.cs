using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{

    [SerializeField] bool isPlacable;
    [SerializeField] GameObject balista;

    public bool IsPlacable { get { return isPlacable; }} //bilgisi donulen property 

    private void OnMouseDown()
    {
        if(isPlacable)
        {
            Instantiate(balista, transform.position, Quaternion.identity);
            isPlacable = false;

        }

    }

}
