using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class WeaponSelect : MonoBehaviour
{
    public bool initialInstantiation = false;

    public string[] customizationOptions;
    public List<Button> buttonReferences;
    public List<Sprite> sprites = new List<Sprite>();

    public GameObject buttonPrefab;
    public Transform parent;
    public UnityEvent OnWeaponSelected;

    private void Awake()
    {
        customizationOptions = System.Enum.GetNames(typeof(WeaponType));
    }

    public void InitializeWeaponSelectScreen()
    {
        if (!initialInstantiation)
        {
            foreach (string option in customizationOptions)
            {
                GameObject tmp = Instantiate(buttonPrefab, parent);

                TMP_Text t = tmp.GetComponentInChildren<TMP_Text>();
                t.text = option;

                Button b = tmp.GetComponent<Button>();
                buttonReferences.Add(b);

                if (t.text == "Sword")
                {
                    b.GetComponentsInChildren<Image>()[1].sprite = sprites[1];
                }

                if (t.text == "Staff")
                {
                    b.GetComponentsInChildren<Image>()[1].sprite = sprites[2];
                }

                if (t.text == "Bomb")
                {
                    b.GetComponentsInChildren<Image>()[1].sprite = sprites[3];
                }

                b.onClick.AddListener(delegate { CharacterSelectSingleton.Instance.SetWeaponType(option); });
                b.onClick.AddListener(delegate { OnWeaponSelected?.Invoke(); });
            }
            initialInstantiation = true;
        }
    }

    public void DisableButtons()
    {
        foreach (Button buttons in buttonReferences)
        {
            buttons.enabled = false;
        }
    }

    public void EnableButtons()
    {
        foreach (Button buttons in buttonReferences)
        {
            buttons.enabled = true;
            buttons.GetComponentsInChildren<Image>()[0].sprite = sprites[0];
        }
    }
}
