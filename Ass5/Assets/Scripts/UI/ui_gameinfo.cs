using UnityEngine;
using TMPro;

public class ui_gameinfo : MonoBehaviour
{
    [SerializeField] TMP_Text ghostType;
    [SerializeField] TMP_Text gamertag;

    void Awake()
    {
        ghostType.text = "TYPE";
        gamertag.text = "NAME";
    }
}
