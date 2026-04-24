using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class CharacterSpawner : MonoBehaviour
{
    [SerializeField] UIGameInfo ui;
    public Transform spawnPoint;
    public List<Material> materials = new List<Material>();
    public int skinIndexHelper = 0;
    private GameObject currentCharacter;

    public void Start()
    {
        skinIndexHelper = 0;

        if (currentCharacter != null)
        {
            Destroy(currentCharacter);
        }

        SpawnCharacter();
    }

    public void SpawnCharacter()
    {
        GameObject characterPrefab = CharacterSelectSingleton.Instance.GetCharacter().prefab;
        currentCharacter = Instantiate(characterPrefab, spawnPoint);

        MeshRenderer mr = currentCharacter.GetComponent<MeshRenderer>();

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

        UpdateGameInfoUI();
    }

    private void UpdateGameInfoUI()
    {
        ui.GetComponent<UIGameInfo>();

        if (ui != null)
        {
            ui.RefreshDisplay();
        }
    }
}