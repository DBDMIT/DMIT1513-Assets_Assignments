using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class UIGameInfo : MonoBehaviour
{
    public int zombieCount = 20;

    [SerializeField] EnemySpawn enemySpawn;

    [SerializeField] TMP_Text ghostType;
    [SerializeField] TMP_Text gamertag;
    [SerializeField] TMP_Text zombieAmount;

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

    public void Update()
    {
        zombieAmount.text = $"{zombieCount} / 20";

        if (zombieCount <= 0)
        {
            StartCoroutine(DieWait());
        }
    }
    IEnumerator DieWait()
    {
        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(3);
    }

    public void DecreaseZombieCount()
    {
        zombieCount--;
    }
}
