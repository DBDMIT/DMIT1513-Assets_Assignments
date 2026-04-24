using UnityEngine;

[CreateAssetMenu(fileName = "CharacterSO", menuName = "Character/CharacterSO")]
public class CharacterSO : ScriptableObject
{
    public string characterName;
    public Sprite characterSprite;

    public int strength, speed, durability;
    public GameObject prefab;
}

public enum Skin
{
    Default,
    MrPill,
    GasMask,
    Phillip
}
