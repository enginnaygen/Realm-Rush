using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] Vector2Int startCoordinates;
    [SerializeField] Vector2Int destinationCoordinates; //end coordinates

    Node startNode;
    Node destinationNode;
    Node currentSearchNode;

    Queue<Node> frontier = new Queue<Node>();
    Dictionary<Vector2Int, Node> reached = new Dictionary<Vector2Int, Node>();

    Vector2Int[] directions = { Vector2Int.right, Vector2Int.left, Vector2Int.up, Vector2Int.down};
    GridManager gridManager;
    Dictionary<Vector2Int, Node> grid = new Dictionary<Vector2Int, Node>();

    private void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();

        if(gridManager != null)
        {
            grid = gridManager.Grid;
        }

        
    }
    void Start()
    {
        startNode = gridManager.Grid[startCoordinates];
        destinationNode = gridManager.Grid[destinationCoordinates];

        GetNewPath();
    }

    public List<Node> GetNewPath()
    {
        gridManager.ResetNode();
        BreadthFirstSearch();
        return BuildPath();
    }

    void ExploreNeighbors()
    {
        List<Node> neighbors = new List<Node>();

        foreach (Vector2Int direction in directions)
        {

            Vector2Int neighborCoordinates = currentSearchNode.coordinates + direction;

          if(grid.ContainsKey(neighborCoordinates))
            {
                neighbors.Add(grid[neighborCoordinates]); //eger neighbour gridde varsa neighbors'a ekle
            }
        }

        foreach(Node neighbour in neighbors)
        {   //her ulasilan yer bir kere algoritma agacinda olmali, yani reached ise eklenmemeli, eklenen bir daha connectedTo olamýyor yani tek bir Node a baglaniyor
            if (!reached.ContainsKey(neighbour.coordinates) && neighbour.isWalkable)
            {
                neighbour.connetedTo = currentSearchNode; //tum komsularý tek bir node a bagliyor, node a baglama islemleri burada oluyor
                reached.Add(neighbour.coordinates, neighbour);
                frontier.Enqueue(neighbour);
            }
        }
    }

    void BreadthFirstSearch()
    {
        frontier.Clear();
        reached.Clear();

        bool isRunning = true;

        frontier.Enqueue(startNode);
        reached.Add(startCoordinates, startNode);

        while(frontier.Count > 0 && isRunning)
        {
            currentSearchNode = frontier.Dequeue(); //frontierin ilk degerini listeden cikartiyor ve currentSN'u cikan degere esitliyor
            currentSearchNode.isExplored = true;
            ExploreNeighbors();
            if(currentSearchNode.coordinates == destinationCoordinates)
            {
                isRunning = false;
            }
        }
    }

    List<Node> BuildPath() 
    {
        List<Node> path = new List<Node>();
        Node currentNode = destinationNode; //tersten baslayip basa dogru gidiyoruz

        path.Add(currentNode);
        currentNode.isPath = true;

        while(currentNode.connetedTo != null)
        {
            currentNode = currentNode.connetedTo;
            path.Add(currentNode);
            currentNode.isPath = true;
        }

        path.Reverse();

        return path;
    }

    public bool WillBlockPath(Vector2Int coordinates) //starttan destinationa yol varsa bloklamýyor
    {                                                 //yoksa false donuyor 
        if(grid.ContainsKey(coordinates))
        {
            bool previousState = grid[coordinates].isWalkable;
            grid[coordinates].isWalkable = false;
            List<Node> newPath = GetNewPath();
            grid[coordinates].isWalkable = previousState;

            if(newPath.Count <=1)
            {
                GetNewPath();
                return true;
            }
        }
        return false;
    }

}
