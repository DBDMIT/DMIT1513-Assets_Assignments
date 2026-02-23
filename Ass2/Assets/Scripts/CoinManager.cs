using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public TextMeshProUGUI coinAmountText;
    public GameObject coinObjects;

    public int coinCount = 0;
    public int coinGoal = 0;
    public bool goalComplete = false;

    private void Start()
    {
        goalComplete = false;

        for (int i = 0; i < coinObjects.transform.childCount; i++)
        {
            coinGoal++;
        }
    }

    public void IncrementCoin()
    {
        coinCount++;
    }

    public void Update()
    {
        coinAmountText.text = $"{coinCount} / {coinGoal}";

        if (coinCount >= coinGoal)
        {
            goalComplete = true;
            SceneManager.LoadScene(0);
        }
    }
}
