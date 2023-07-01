using UnityEngine;
using TMPro;

public class GarbageTextSetup : MonoBehaviour
{
    public TextMeshProUGUI GarbageCounterText;
    public TextMeshProUGUI GarbageDepositedText;
    [HideInInspector] public int GarbageDeposited = 0;
    [HideInInspector] public int GarbageCollected = 0;
    
    void Update()
    {
        GarbageCounterText.text = "Garbage Picked: " + GarbageCollected;
        GarbageDepositedText.text = "Garbage Deposited: " + GarbageDeposited;
    }
}