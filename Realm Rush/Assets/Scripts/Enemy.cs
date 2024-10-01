using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int goldReward = 25;
    [SerializeField] int goldPenalty = 25;

    Bank bank;
    UI ui;

    private void Awake()
    {
        bank = FindObjectOfType<Bank>();
        ui = FindObjectOfType<UI>();
    }

    public void EarnMoney()
    {
        if (bank == null) return;
        bank.Deposit(goldReward);
        ui.UpdeteGoldText();
    }

    public void LoseMoney()
    {
        if (bank == null) return;
        bank.Withdraw(goldPenalty);
        ui.UpdeteGoldText();
    }


}
