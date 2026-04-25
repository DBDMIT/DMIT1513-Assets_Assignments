using UnityEngine;

public class AudioPlay : MonoBehaviour
{
    [SerializeField] string SongTitle;
    void Start()
    {
        MusicManager.Instance.PlayMusic(SongTitle);
    }
}
