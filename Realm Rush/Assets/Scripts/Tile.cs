using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour //burada tower(balista) olusturuluyor
{

    [SerializeField] bool isPlacable;
    [SerializeField] Balista balista;
    GridManager gridManager;
    Vector2Int coordinates = new Vector2Int();
    public bool IsPlacable { get { return isPlacable; }} //bilgisi donulen property 

    private void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
    }

    private void Start()
    {
        if(gridManager != null)
        {
            coordinates = gridManager.GetCoordinatesFromPosition(transform.position);

            if(!isPlacable)
            {
                gridManager.BlockNode(coordinates);
            }
        }
    }
    private void OnMouseDown()
    {
        if(isPlacable)
        {
            bool isPlaced = balista.InstantiateTower(balista, transform);
            isPlacable = !isPlaced; 

        }

    }

}
