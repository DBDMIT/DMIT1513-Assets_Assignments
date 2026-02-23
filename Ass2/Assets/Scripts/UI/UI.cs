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

    public void QuitGame()
    {
        Application.Quit();
    }
}
