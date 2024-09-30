using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] int poolSize = 5;
    [SerializeField] float spawnTimer = 1f;

    [SerializeField] GameObject[] pool;

    private void Awake()
    {
        PopulatePool();
    }
    void Start()
    {
        StartCoroutine("SpawnEnemy");
    }

    void PopulatePool()
    {
        pool = new GameObject[poolSize];

        for (int i = 0; i < pool.Length; i++)
        {
            //GameObject enemymember = Instantiate(enemy, transform);
            //pool[i] = enemymember;
            pool[i] = Instantiate(enemy, transform);
            pool[i].SetActive(false);

        }
    }

    void EnableObjectInPool()
    {
        for (int i = 0; i < pool.Length; i++)
        {
            if (!pool[i].activeInHierarchy)
            {
                pool[i].SetActive(true);
                return;
            }
        }
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            EnableObjectInPool();
            yield return new WaitForSeconds(spawnTimer);
        }
        
    }

    
}
