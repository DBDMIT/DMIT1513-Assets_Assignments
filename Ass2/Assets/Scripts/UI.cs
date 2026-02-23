using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
public class UI : MonoBehaviour
{
    public CoinManager coinManager;
    public TextMeshProUGUI coinAmountText;
    public TextMeshProUGUI UIText;

    private void Start()
    {
        UIText.text = "Mr. Pill Collects Coines & Drives & Also Dies Sometimes";
    }

    public void Update()
    {
        if (coinManager.goalComplete)
        {
            UIText.text = "You won! Play again please.";
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
