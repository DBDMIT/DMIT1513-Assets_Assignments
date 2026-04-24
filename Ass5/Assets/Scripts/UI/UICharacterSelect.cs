using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.TextCore.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using NUnit.Framework;

public class UICharacterSelect : MonoBehaviour
{
    public bool initialInstantiation = false;

    public List<Button> buttonReferences;
    public List<Sprite> sprites = new List<Sprite>();
    public CharacterSO[] characterList;

    public Transform parent;
    public GameObject buttonPrefab;
    public UnityEvent OncharacterSelected;
    public static UICharacterSelect Instance;

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
