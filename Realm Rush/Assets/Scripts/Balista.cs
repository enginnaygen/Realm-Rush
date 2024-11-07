using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balista : MonoBehaviour
{
    [SerializeField] int balistaCost = 50;
    [SerializeField] GameObject topBalista, baseBalista;

    private void Start()
    {
        StartCoroutine(Build());
    }

    public bool InstantiateTower(Balista balista,Transform tile)
    {
        Bank bank;
        bank = FindObjectOfType<Bank>();



        if (bank == null)
        {
            return false;
        }

        if(bank.CurrentBalance >= balistaCost)
        {
            Instantiate(balista, tile.position, Quaternion.identity);
            bank.Withdraw(balistaCost);
            return true;
        }

        return false;
    }

    IEnumerator Build()
    {
        topBalista.SetActive(false);
        baseBalista.SetActive(false);

        yield return new WaitForSeconds(0.2f);
        baseBalista.SetActive(true);
        yield return new WaitForSeconds(0.8f);
        topBalista.SetActive(true);

    }

}
