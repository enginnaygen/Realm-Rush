using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform target, weapon;
    [SerializeField] ParticleSystem projectilePartical;
    [SerializeField] float rannge = 15;

    void Update()
    {
        FindClosestTarget();
        AimWeapon();
    }

    void FindClosestTarget()
    {
        Enemy[] enemies =  FindObjectsOfType<Enemy>();
        Transform closestTarget = null;
        float maxDistance = Mathf.Infinity;

        foreach (Enemy enemy in enemies)
        {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);

            if(targetDistance < maxDistance)
            {
                closestTarget = enemy.transform;
                maxDistance = targetDistance;
            }

            
        }
        target = closestTarget;
    }


    private void AimWeapon()
    {
        float targetDistance = Vector3.Distance(transform.position, target.position);

        if(targetDistance < rannge)
        {
            Attack(true);
        }
        else
        {
            Attack(false);
        }

        weapon.LookAt(target);
    }

    void Attack(bool isActive)
    {
        var emissionModule = projectilePartical.emission;
        emissionModule.enabled = isActive;
        /*if(isActive)
        {
            projectilePartical.emissionRate = 1;
        }
        else
        {
            projectilePartical.emissionRate = 0;
        }*/
    }
}
