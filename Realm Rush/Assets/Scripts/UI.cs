using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI goldText;
    Bank bank;

    private void Start()
    {
        bank = FindObjectOfType<Bank>();
        UpdeteGoldText();
    }
    public void UpdeteGoldText()
    {
        goldText.text = "Gold:" + bank.CurrentBalance;
    }
}
