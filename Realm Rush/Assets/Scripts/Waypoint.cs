using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour //burada tower(balista) olusturuluyor
{

    [SerializeField] bool isPlacable;
    [SerializeField] Balista balista;

    public bool IsPlacable { get { return isPlacable; }} //bilgisi donulen property 

    private void OnMouseDown()
    {
        if(isPlacable)
        {
            bool isPlaced = balista.InstantiateTower(balista, transform);
            isPlacable = !isPlaced; 

        }

    }

}
