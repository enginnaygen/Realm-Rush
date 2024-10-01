using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int goldReward = 25;
    [SerializeField] int goldPenalty = 25;

    Bank bank;

    private void Awake()
    {
        bank = FindObjectOfType<Bank>();
    }

    public void EarnMoney()
    {
        if (bank == null) return;
        bank.Deposit(goldReward);
    }

    public void LoseMoney()
    {
        if (bank == null) return;
        bank.Withdraw(goldPenalty);
    }


}
