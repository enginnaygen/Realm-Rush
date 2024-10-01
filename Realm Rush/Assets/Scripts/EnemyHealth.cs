using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5;
    [SerializeField] int currentHitPoint = 0;

    Enemy enemy;

    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        currentHitPoint++;

        if (currentHitPoint >= maxHitPoints)
        {
            //Destroy(gameObject);
            enemy.EarnMoney();
            currentHitPoint = 0;
            gameObject.SetActive(false);
        }
    }
}
