using UnityEngine;
using TMPro;

public class CoinCounter : MonoBehaviour
{
    public TextMeshProUGUI CoinCounterText;
    public int CoinCollected = 0;

    private void Update() 
    {
        CoinCounterText.text = CoinCollected.ToString();
    }
}