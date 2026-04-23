using NUnit.Framework;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class CharacterSelectScreen : MonoBehaviour
{
    public bool initialInstantiation = false;

    public List<Button> buttonReferences;
    public CharacterSO[] characterList;

    public UnityEvent OncharacterSelected;
    public static CharacterSelectScreen Instance;

    [ContextMenu("debug")]

    private void Awake()
    {
        InstantiateCharacterSelect();
    }

    public void InstantiateCharacterSelect()
    {
        if (!initialInstantiation)
        {
            for (int i = 0; i < characterList.Length; i++)
            {
                CharacterSO character = characterList[i];
                Button button = buttonReferences[i];

                button.onClick.AddListener(delegate { SelectCharacter(character); });
            }

            initialInstantiation = true;
        }
    }

    public void SelectCharacter(CharacterSO c)
    {
        CharacterSelectSingleton.Instance.SetCharacter(c);
        OncharacterSelected?.Invoke();
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
        }
    }
}

