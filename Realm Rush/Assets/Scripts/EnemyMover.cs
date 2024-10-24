using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Tile> path = new List<Tile>();
    [Range(0,10)] [SerializeField] float speed = 1f;

    Enemy enemy;

    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }
    void OnEnable()
    {
        PathFinding();
        ReturnToStart();
        StartCoroutine(FallowPath());
    }

    void ReturnToStart()
    {
        transform.position = path[0].transform.position;
    }

    void PathFinding()
    {
        path.Clear();

        GameObject parent = GameObject.FindGameObjectWithTag("Path");

        foreach (Transform child in parent.transform)
        {
            Tile waypoint = child.GetComponentInChildren<Tile>();

            if(waypoint!=null)
            {
                path.Add(waypoint);

            }
        }
    }


    void FinishPath()
    {
        enemy.LoseMoney();
        gameObject.SetActive(false);

    }
    IEnumerator FallowPath()
    {
        foreach (Tile waypoint in path)
        {
            Vector3 startPos = transform.position;
            Vector3 endPos = waypoint.transform.position;
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
