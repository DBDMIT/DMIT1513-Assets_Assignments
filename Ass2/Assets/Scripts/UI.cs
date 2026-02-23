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
        if (coinManager.coinCount == coinManager.coinGoal)
        {
            UIText.text = "You won! Play again please.";
            SceneManager.LoadScene(0);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
