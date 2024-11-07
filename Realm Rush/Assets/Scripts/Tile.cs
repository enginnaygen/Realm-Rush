using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour //burada tower(balista) olusturuluyor
{

    [SerializeField] bool isPlacable;
    [SerializeField] Balista balista;

    GridManager gridManager;
    Pathfinder pathFinder;

    Vector2Int coordinates = new Vector2Int();
    public bool IsPlacable { get { return isPlacable; }} //bilgisi donulen property 

    private void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        pathFinder = FindObjectOfType<Pathfinder>();
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
        if (gridManager.GetNode(coordinates).isWalkable && !pathFinder.WillBlockPath(coordinates))
        {
            bool isSuccesful = balista.InstantiateTower(balista, transform);

            if(isSuccesful)
            {
                gridManager.BlockNode(coordinates);
                pathFinder.NotifyReciever();
            }

        }

    }

}
