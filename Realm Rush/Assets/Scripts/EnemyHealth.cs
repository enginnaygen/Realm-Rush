using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [Tooltip("Do not enter negative values")][SerializeField] int maxHitPoints = 5;
    [Tooltip("Adds amount to maxHitPoints when enemy dies")][SerializeField] int difficultyRamp = 1;

    int currentHitPoint = 0;

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
            maxHitPoints += difficultyRamp;
            gameObject.SetActive(false);
        }
    }
}
