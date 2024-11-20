using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance;
    [SerializeField] int currentBalance;
    [SerializeField] TextMeshProUGUI goldText;
    public int CurrentBalance { get { return currentBalance; }}

    private void Start()
    {
        currentBalance = startingBalance;
        UpdateGoldDisplay();
    }
    public void Deposit(int amount)
    {
        if(amount>0)
        {
            currentBalance += amount;
            UpdateGoldDisplay();

        }
    }

    public void Withdraw(int amount)
    {
        currentBalance -= amount;
        UpdateGoldDisplay();
        if (currentBalance<0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void UpdateGoldDisplay()
    {
        goldText.text = "Gold:" + currentBalance;

    }
}
