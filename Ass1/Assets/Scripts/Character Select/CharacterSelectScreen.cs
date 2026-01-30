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
    public List<Sprite> sprites = new List<Sprite>();
    public CharacterSO[] characterList;

    public Transform parent;
    public GameObject buttonPrefab;
    public UnityEvent OncharacterSelected;
    public static CharacterSelectScreen Instance;

    [ContextMenu("debug")]

    public void InstantiateCharacterSelect()
    {
        if (!initialInstantiation)
        {
            foreach(CharacterSO character in characterList)
            {
                GameObject tmp = Instantiate(buttonPrefab, parent);
                Image portrait = tmp.GetComponentsInChildren<Image>()[1];
                Image indicator = tmp.GetComponentsInChildren<Image>()[1];
                portrait.sprite = character.characterSprite;
                indicator.sprite = character.characterSprite;

                Button b = tmp.GetComponent<Button>();
                buttonReferences.Add(b);
                b.onClick.AddListener(delegate { SelectCharacter(character); });
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
            buttons.GetComponentsInChildren<Image>()[0].sprite = sprites[0];
        }
    }
}

