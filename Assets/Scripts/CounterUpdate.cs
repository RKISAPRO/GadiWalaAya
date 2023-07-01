using UnityEngine;

public class CounterUpdate : MonoBehaviour
{
    public GarbageTextSetup garbagetextsetup;
    public UIEvents UIEvents;
    private const string Garbage = "Garbage";

    private void OnCollisionEnter(Collision col) 
    {
        if(col.collider.CompareTag(Garbage) && UIEvents.MoreGarbagePickUpgradeLevel == 0)
        {
            garbagetextsetup.GarbageCollected += 1;
        }

        if(col.collider.CompareTag(Garbage) && UIEvents.MoreGarbagePickUpgradeLevel == 1)
        {
            garbagetextsetup.GarbageCollected += 2;
        }

        if(col.collider.CompareTag(Garbage) && UIEvents.MoreGarbagePickUpgradeLevel == 2)
        {
            garbagetextsetup.GarbageCollected += 5;
        }

        if(col.collider.CompareTag(Garbage) && UIEvents.MoreGarbagePickUpgradeLevel == 3)
        {
            garbagetextsetup.GarbageCollected += 10;
        }
    }
}