using UnityEngine;

[CreateAssetMenu(fileName = "CharacterSO", menuName = "Character/CharacterSO")]
public class CharacterSO : ScriptableObject
{
    public string characterName;
    public Sprite characterSprite;

    public int strength, speed, durability;
    public WeaponType weaponType;
    public GameObject prefab;
}

public enum WeaponType
{
    Sword,
    Gun,
    Punch
}

public enum Skin
{
    Default,
    Witch,
    Wizard,
    Bikini    
}
