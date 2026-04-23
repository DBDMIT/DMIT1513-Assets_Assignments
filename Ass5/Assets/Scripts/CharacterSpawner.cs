using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class CharacterSpawner : MonoBehaviour
{
    public Transform spawnPoint;
    public List<Material> materials = new List<Material>();
    public int skinIndexHelper = 0;

    public void Start()
    {
        SpawnCharacter();
    }

    public void SpawnCharacter()
    {
        GameObject characterPrefab = CharacterSelectSingleton.Instance.GetCharacter().prefab;
        GameObject tmp = Instantiate(characterPrefab, spawnPoint);

        MeshRenderer mr = tmp.GetComponent<MeshRenderer>();

        if (characterPrefab.gameObject.name == "Player_Staff")
        {
            skinIndexHelper = 0;
        }

        if (characterPrefab.gameObject.name == "Player_Sword")
        {
            skinIndexHelper = 4;
        }

        if (characterPrefab.gameObject.name == "Player_Wrench")
        {
            skinIndexHelper = 8;
        }

        mr.sharedMaterial = materials[CharacterSelectSingleton.Instance.getSkin() + skinIndexHelper];
    }
}