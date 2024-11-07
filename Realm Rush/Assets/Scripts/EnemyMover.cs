using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    [Range(0,10)] [SerializeField] float speed = 1f;

    List<Node> path = new List<Node>();

    Enemy enemy;
    Pathfinder pathFinder;
    GridManager gridManager;

    void OnEnable()
    {
        RecalculatePath();
        ReturnToStart();
        StartCoroutine(FallowPath());
    }

    private void Awake()
    {
        enemy = GetComponent<Enemy>();
        pathFinder = FindObjectOfType<Pathfinder>();
        gridManager = FindObjectOfType<GridManager>();

    }
   

    void ReturnToStart()
    {
        transform.position = gridManager.GetPositionFromCoordinates(pathFinder.StartCoordinates);
    }

    void RecalculatePath()
    {
        path.Clear();
        path = pathFinder.GetNewPath();
    }


    void FinishPath()
    {
        enemy.LoseMoney();
        gameObject.SetActive(false);

    }
    IEnumerator FallowPath()
    {
        for(int i = 0; i < path.Count; i++)
        {
            Vector3 startPos = transform.position;
            Vector3 endPos = gridManager.GetPositionFromCoordinates(path[i].coordinates);
            float travelPercent = 0f;

            transform.LookAt(endPos);

            while(travelPercent<1)
            {
                travelPercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPos, endPos, travelPercent); //iki nokta arasındaki ilerleme oranini veriyor
                yield return new WaitForEndOfFrame();
            }

        }

        FinishPath();
    }



}
