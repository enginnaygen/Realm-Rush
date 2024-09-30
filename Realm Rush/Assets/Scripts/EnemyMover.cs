using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [Range(0,10)] [SerializeField] float speed = 1f;

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
            path.Add(child.GetComponentInChildren<Waypoint>());
        }
    }

    IEnumerator FallowPath()
    {
        foreach (Waypoint waypoint in path)
        {
            Vector3 startPos = transform.position;
            Vector3 endPos = waypoint.transform.position;
            float travelPercent = 0f;

            transform.LookAt(endPos);

            while(travelPercent<1)
            {
                travelPercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPos, endPos, travelPercent); //iki nokta arasýndaki ilerleme oranini veriyor
                yield return new WaitForEndOfFrame();
            }

        }

        //Destroy(gameObject); //yolunu bitirince kendini yok ediyor
        gameObject.SetActive(false);
        //transform.localPosition = Vector3.zero;
    }



}
