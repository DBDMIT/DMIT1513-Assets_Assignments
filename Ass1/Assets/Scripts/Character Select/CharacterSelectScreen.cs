using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CharacterSelectScreen : MonoBehaviour
{
    public CharacterSO[] characterList;
    public Transform parent;
    public GameObject buttonPrefab;

    public UnityEvent OncharacterSelected;
    public static CharacterSelectScreen Instance;

    public List<Button> buttonReferences;

    [ContextMenu("debug")]
    public void InstantiateCharacterSelect()
    {
        foreach(CharacterSO character in characterList)
        {
            GameObject tmp = Instantiate(buttonPrefab, parent);
            Image portrait = tmp.GetComponentsInChildren<Image>()[1];
            portrait.sprite = character.characterSprite;

            Button b = tmp.GetComponent<Button>();
            buttonReferences.Add(b);
            b.onClick.AddListener(delegate { SelectCharacter(character); });
        }
    }

    public void SelectCharacter(CharacterSO c)
    {
        CharacterSelectSingleton.Instance.SetCharacter(c);
        OncharacterSelected?.Invoke();
    }

    public void DisableButtons()
    {
        foreach (Button b in buttonReferences)
        {
            b.enabled = false;
        }
    }

    public void EnableButtons()
    {
        foreach (Button b in buttonReferences)
        {
            b.enabled = true;
        }
    }
}

