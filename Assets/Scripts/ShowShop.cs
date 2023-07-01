using UnityEngine;

public class ShowShop : MonoBehaviour
{
    private ShowDeposit ShowDeposit;
    private UIEvents UIEvents;
    public GameObject ShopObj;
    public GameObject ShopPanel;
    public LayerMask Shop;
    public KeyCode ShopKey = KeyCode.E;
    public KeyCode MiniShopKey = KeyCode.M;
    public float ShopPlayerRange = 1;
    private bool playerInShopRange;
    [HideInInspector] public bool ShopPanelOpen;
    public GameObject UpgradesPanel;
    public GameObject ItemsPanel;

    private void Start() 
    {
        ShowDeposit = GetComponent<ShowDeposit>();
        UIEvents = FindObjectOfType<UIEvents>();
    }
    
    private void Update()
    {
        playerInShopRange = Physics.CheckSphere(transform.position, ShopPlayerRange, Shop);
        
        if(playerInShopRange)
        {
            ShopObj.gameObject.SetActive(true);
        }
        else
        {
            ShopObj.gameObject.SetActive(false);
        }

        if(playerInShopRange && Input.GetKey(ShopKey))
        {
            ShopPanel.gameObject.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            ShowDeposit.gameCam.gameObject.SetActive(false);
            ShopPanelOpen = true;
            UIEvents.UpgradesMenuIsActive = true;
            UIEvents.ItemsMenuIsActive = false;
        }
        else if(!playerInShopRange && !ShowDeposit.DepositerPanelOpen)
        {
            ShopPanel.gameObject.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            ShowDeposit.gameCam.gameObject.SetActive(true);
            ShopPanelOpen = false;
        }

        if(UIEvents.UpgradesMenuIsActive)
        {
            UpgradesPanel.gameObject.SetActive(true);
            ItemsPanel.gameObject.SetActive(false);
        }
        else if(UIEvents.ItemsMenuIsActive)
        {
            UpgradesPanel.gameObject.SetActive(false);
            ItemsPanel.gameObject.SetActive(true);
        }

        if(UIEvents.MiniGarbageBinItemPurchased && Input.GetKey(MiniShopKey) && !ShowDeposit.DepositerPanelOpen)
        {
            ShopPanel.gameObject.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            ShowDeposit.gameCam.gameObject.SetActive(false);
            ShopPanelOpen = true;
            UIEvents.UpgradesMenuIsActive = true;
            UIEvents.ItemsMenuIsActive = false;
        }
    }

    public void CloseSetup()
    {
        ShopPanel.gameObject.SetActive(false);
        ShowDeposit.gameCam.gameObject.SetActive(true);
        ShopPanelOpen = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}