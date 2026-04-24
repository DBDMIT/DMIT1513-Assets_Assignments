using UnityEngine;
using TMPro;

public class UIGameInfo : MonoBehaviour
{
    [SerializeField] TMP_Text ghostType;
    [SerializeField] TMP_Text gamertag;
    private CharacterSelectSingleton Instance;

    void Start()
    {
        Instance = CharacterSelectSingleton.Instance;

        if (Instance == null)
        {
            Debug.Log("CharacterSelectSingleton not found!");
            return;
        }

        ghostType.text = Instance.selectedCharacter.characterName;
        gamertag.text = Instance.gamertag.ToString();

        RefreshDisplay();
    }

    public void RefreshDisplay()
    {
        ghostType.text = Instance.selectedCharacter.characterName;
        gamertag.text = Instance.gamertag.ToString();
    }
}
