using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5;
    [SerializeField] int currentHitPoint = 0;

    private void OnParticleCollision(GameObject other)
    {
        currentHitPoint++;

        if(currentHitPoint >= maxHitPoints)
        {
            //Destroy(gameObject);
            currentHitPoint = 0;
            gameObject.SetActive(false);
        }
    }
}
