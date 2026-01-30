using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class WeaponSelect : MonoBehaviour
{
    public string[] customizationOptions;
    public GameObject buttonPrefab;
    public Transform parent;
    public UnityEvent OnWeaponSelected;
    public List<Sprite> sprites = new List<Sprite>();
    public bool initialInstantiation = false;

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

                if (t.text == "Sword")
                {
                    b.GetComponentsInChildren<Image>()[1].sprite = sprites[0];
                }

                if (t.text == "Staff")
                {
                    b.GetComponentsInChildren<Image>()[1].sprite = sprites[1];
                }

                if (t.text == "Bomb")
                {
                    b.GetComponentsInChildren<Image>()[1].sprite = sprites[2];
                }

                b.onClick.AddListener(delegate { CharacterSelectSingleton.Instance.SetWeaponType(option); });
                b.onClick.AddListener(delegate { OnWeaponSelected?.Invoke(); });
            }

            initialInstantiation = true;
        }
    }
}
