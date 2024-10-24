using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balista : MonoBehaviour
{
    [SerializeField] int balistaCost = 50;

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

}
