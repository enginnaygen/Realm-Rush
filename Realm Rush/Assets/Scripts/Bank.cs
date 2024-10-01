using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance;
    [SerializeField] int currentBalance;
    public int CurrentBalance { get { return currentBalance; }}

    private void Start()
    {
        currentBalance = startingBalance;
    }
    public void Deposit(int amount)
    {
        if(amount>0)
        {
            currentBalance += amount;
        }
    }

    public void Withdraw(int amount)
    {
        currentBalance -= amount;
    }
}
