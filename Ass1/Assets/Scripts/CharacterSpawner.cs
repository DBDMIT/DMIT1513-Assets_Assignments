using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class CharacterSpawner : MonoBehaviour
{
    public Transform spawnPoint;
    public List<Material> materials = new List<Material>();

    public void Spawncharacter()
    {
        GameObject characterPrefab = CharacterSelectSingleton.Instance.GetCharacter().prefab;
        GameObject tmp = Instantiate(characterPrefab, spawnPoint);

        MeshRenderer mr = tmp.GetComponent<MeshRenderer>();
        mr.sharedMaterial = materials[CharacterSelectSingleton.Instance.getSkin()];
    }
}