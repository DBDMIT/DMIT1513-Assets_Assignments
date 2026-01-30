using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class CharacterSpawner : MonoBehaviour
{
    public Transform spawnPoint;
    public List<Material> materials = new List<Material>();
    public int skinIndexHelper = 0;

    public void Spawncharacter()
    {
        GameObject characterPrefab = CharacterSelectSingleton.Instance.GetCharacter().prefab;
        GameObject tmp = Instantiate(characterPrefab, spawnPoint);

        MeshRenderer mr = tmp.GetComponent<MeshRenderer>();

        if (characterPrefab.gameObject.name == "Character Ghost Engineer")
        {
            skinIndexHelper = 4;
        }

        if (characterPrefab.gameObject.name == "Character Ghost Bomber")
        {
            skinIndexHelper = 8;
        }

        mr.sharedMaterial = materials[CharacterSelectSingleton.Instance.getSkin() + skinIndexHelper];
    }
}