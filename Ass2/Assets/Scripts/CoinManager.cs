using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public int coinCount = 0;

    public void IncrementCoin()
    {
        coinCount++;
    }

    public void Update()
    {
        if (coinCount >= 50)
        {
            Debug.Log("GAME SHOULD END");
        }
    }
}
