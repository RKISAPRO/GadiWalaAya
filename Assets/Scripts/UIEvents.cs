using UnityEngine;

public class UIEvents : MonoBehaviour
{
    private GarbageTextSetup GarbageTextSetup;
    private CoinCounter CoinCounter;
    private ShowDeposit ShowDeposit;
    private ShowShop ShowShop;
    [HideInInspector] public bool UpgradesMenuIsActive;
    [HideInInspector] public bool ItemsMenuIsActive;
    public int fastspeedupgradelevel1price;
    public int fastspeedupgradelevel2price;
    public int fastspeedupgradelevel3price;
    public int moregarbagepickupgradelevel1price;
    public int moregarbagepickupgradelevel2price;
    public int moregarbagepickupgradelevel3price;
    [HideInInspector] public int FastSpeedUpgradeLevel = 0;
    [HideInInspector] public int MoreGarbagePickUpgradeLevel = 0;
    private bool Moregarbagepickupgradelevel1purchased = false;
    private bool Moregarbagepickupgradelevel2purchased = false;
    private bool Moregarbagepickupgradelevel3purchased = false;
    private bool Fastspeedupgradelevel1purchased = false;
    private bool Fastspeedupgradelevel2purchased = false;
    private bool Fastspeedupgradelevel3purchased = false;
    public GameObject FSUL2B;
    public GameObject FSUL3B;
    public GameObject MGPUL2B;
    public GameObject MGPUL3B;
    public GameObject FSUL1PB;
    public GameObject FSUL2PB;
    public GameObject FSUL3PB;
    public GameObject MGPUL1PB;
    public GameObject MGPUL2PB;
    public GameObject MGPUL3PB;
    public float MoveSpeedUpgradeIncreaseValueForLevel1;
    public float MoveSpeedUpgradeIncreaseValueForLevel2;
    public float MoveSpeedUpgradeIncreaseValueForLevel3;
    [HideInInspector] public bool MiniGarbageBinItemPurchased = false;
    [HideInInspector] public bool MiniShopStallItemPurchased = false;
    public int minigarbagebinitemprice;
    public int minishopstallitemprice;
    public GameObject MGBIB;
    public GameObject MSSIB;
    
    private void Start() 
    {
        GarbageTextSetup = GetComponent<GarbageTextSetup>();
        CoinCounter = GetComponent<CoinCounter>();
        ShowShop = FindObjectOfType<ShowShop>();
        ShowDeposit = FindObjectOfType<ShowDeposit>();
    }
    
    public void DepositClose()
    {
        ShowDeposit.CloseSetup();
    }

    public void ShopClose()
    {
        ShowShop.CloseSetup();
    }

    public void Deposit()
    {
        CoinCounter.CoinCollected += GarbageTextSetup.GarbageCollected;
        GarbageTextSetup.GarbageDeposited += GarbageTextSetup.GarbageCollected;
        GarbageTextSetup.GarbageCollected -= GarbageTextSetup.GarbageCollected;
    }

    public void ShowUpgrades()
    {
        UpgradesMenuIsActive = true;
        ItemsMenuIsActive = false;
    }

    public void ShowItems()
    {
        UpgradesMenuIsActive = false;
        ItemsMenuIsActive = true;
    }

    public void PurchaseFastSpeedUpgradeLevel1()
    {
        if(CoinCounter.CoinCollected >= fastspeedupgradelevel1price && !Fastspeedupgradelevel1purchased && FastSpeedUpgradeLevel == 0)
        {
            CoinCounter.CoinCollected -= fastspeedupgradelevel1price;
            FastSpeedUpgradeLevel = 1;
            Fastspeedupgradelevel1purchased = true;
            FSUL2B.gameObject.SetActive(false);
            FSUL1PB.gameObject.SetActive(true);
        }
    }

    public void PurchaseFastSpeedUpgradeLevel2()
    {
        if(CoinCounter.CoinCollected >= fastspeedupgradelevel2price && !Fastspeedupgradelevel2purchased && FastSpeedUpgradeLevel == 1)
        {
            CoinCounter.CoinCollected -= fastspeedupgradelevel2price;
            FastSpeedUpgradeLevel = 2;
            Fastspeedupgradelevel2purchased = true;
            FSUL3B.gameObject.SetActive(false);
            FSUL2PB.gameObject.SetActive(true);
        }
    }

    public void PurchaseFastSpeedUpgradeLevel3()
    {
        if(CoinCounter.CoinCollected >= fastspeedupgradelevel3price && !Fastspeedupgradelevel3purchased && FastSpeedUpgradeLevel == 2)
        {
            CoinCounter.CoinCollected -= fastspeedupgradelevel3price;
            FastSpeedUpgradeLevel = 3;
            Fastspeedupgradelevel3purchased = true;
            FSUL3PB.gameObject.SetActive(true);
        }
    }

    public void PurchaseMoreGarbagePickUpgradeLevel1()
    {
        if(CoinCounter.CoinCollected >= moregarbagepickupgradelevel1price && !Moregarbagepickupgradelevel1purchased && MoreGarbagePickUpgradeLevel == 0)
        {
            CoinCounter.CoinCollected -= moregarbagepickupgradelevel1price;
            MoreGarbagePickUpgradeLevel = 1;
            Moregarbagepickupgradelevel1purchased = true;
            MGPUL2B.gameObject.SetActive(false);
            MGPUL1PB.gameObject.SetActive(true);
        }
    }

    public void PurchaseMoreGarbagePickUpgradeLevel2()
    {
        if(CoinCounter.CoinCollected >= moregarbagepickupgradelevel2price && !Moregarbagepickupgradelevel2purchased && MoreGarbagePickUpgradeLevel == 1)
        {
            CoinCounter.CoinCollected -= moregarbagepickupgradelevel2price;
            MoreGarbagePickUpgradeLevel = 2;
            Moregarbagepickupgradelevel2purchased = true;
            MGPUL3B.gameObject.SetActive(false);
            MGPUL2PB.gameObject.SetActive(true);
        }
    }

    public void PurchaseMoreGarbagePickUpgradeLevel3()
    {
        if(CoinCounter.CoinCollected >= moregarbagepickupgradelevel3price && !Moregarbagepickupgradelevel3purchased && MoreGarbagePickUpgradeLevel == 2)
        {
            CoinCounter.CoinCollected -= moregarbagepickupgradelevel3price;
            Moregarbagepickupgradelevel3purchased = true;
            MoreGarbagePickUpgradeLevel = 3;
            MGPUL3PB.gameObject.SetActive(true);
        }
    }

    public void PurchaseMiniGarbageBinItem()
    {
        if(CoinCounter.CoinCollected >= minigarbagebinitemprice && !MiniGarbageBinItemPurchased)
        {
            CoinCounter.CoinCollected -= minigarbagebinitemprice;
            MiniGarbageBinItemPurchased = true;
            MGBIB.gameObject.SetActive(true);
        }
    }

    public void PurchaseMiniShopStallItem()
    {
        if(CoinCounter.CoinCollected >= minishopstallitemprice && !MiniShopStallItemPurchased)
        {
            CoinCounter.CoinCollected -= minishopstallitemprice;
            MiniShopStallItemPurchased = true;
            MSSIB.gameObject.SetActive(true);
        }
    }
}