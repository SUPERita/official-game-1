using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cash : MonoBehaviour
{
    private TextMeshProUGUI textUI;
    private int cashAmount;

    private void Start()
    {
        textUI = GetComponent<TextMeshProUGUI>();
        LoadCash();
        UpdateCash();
    }

    public int GetCash()
    {
        return cashAmount;
    }

    public void Add(int amount)
    {
        cashAmount += amount;
        SaveCash();
        UpdateCash();
    }

    public void Take(int amount)
    {
        cashAmount -= amount;
        SaveCash();
        UpdateCash();
    }

    private void UpdateCash()
    {
        textUI.text = "coins: " + cashAmount;
    }


    private void LoadCash()
    {
        int[] tmp = SaveSystem.LoadFromLocation("Player_Cash");
        if (tmp != null)
        {
            cashAmount = tmp[0];
        }
        else
        {
            cashAmount = 0;
            SaveCash();
        }
    }

    private void SaveCash()
    {
        SaveSystem.SaveAtLocation(new int[] { cashAmount }, "Player_Cash");

    }
}
