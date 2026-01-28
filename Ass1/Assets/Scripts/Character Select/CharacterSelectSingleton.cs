using UnityEngine;

public class CharacterSelectSingleton : MonoBehaviour
{
    public static CharacterSelectSingleton Instance;
    public CharacterSO selectedCharacter;
    public string weaponType;
    public string gamertag;
    public int skin = 0;
    private void Start()
    {
        if (Instance == null) Instance = this;
    }

    public void SetCharacter(CharacterSO character_) { selectedCharacter= character_; }
    public CharacterSO GetCharacter() { return selectedCharacter; }
    public void SetWeaponType(string s) { weaponType = s; }

    public void SetGamertag(string s) { gamertag = s; }
    public string GetgamerTag() { return gamertag; }

    public void SetSkin (int index)
    {
        skin = index;
    }
    public int getSkin() { return skin; }
}
