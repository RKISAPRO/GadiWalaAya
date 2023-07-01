using UnityEngine;

public class ShowDeposit : MonoBehaviour
{
    private ShowShop ShowShop;
    private UIEvents UIEvents;
    public GameObject depositerObj;
    public GameObject depositerPanel;
    public float PlayerRange = 1;
    private bool playerInRange;
    public LayerMask Depositer;
    public KeyCode DepositKey = KeyCode.E;
    public KeyCode MiniDepositKey = KeyCode.N;
    public GameObject gameCam;
    [HideInInspector] public bool DepositerPanelOpen;

    private void Start() 
    {
        ShowShop = GetComponent<ShowShop>();
        UIEvents = GetComponent<UIEvents>();
    }
    
    private void Update()
    {
        playerInRange = Physics.CheckSphere(transform.position, PlayerRange, Depositer);

        if(playerInRange)
        {
            depositerObj.gameObject.SetActive(true);
        }
        else
        {
            depositerObj.gameObject.SetActive(false);
        }

        if(playerInRange && Input.GetKey(DepositKey))
        {
            depositerPanel.gameObject.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            gameCam.gameObject.SetActive(false);
            DepositerPanelOpen = true;
        }
        else if(!playerInRange && !ShowShop.ShopPanelOpen)
        {
            depositerPanel.gameObject.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            gameCam.gameObject.SetActive(true);
            DepositerPanelOpen = false;
        }

        if(UIEvents.MiniGarbageBinItemPurchased && Input.GetKey(MiniDepositKey) && !ShowShop.ShopPanelOpen)
        {
            depositerPanel.gameObject.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            gameCam.gameObject.SetActive(false);
            DepositerPanelOpen = true;
        }
    }
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, PlayerRange);
    }

    public void CloseSetup()
    {
        depositerPanel.gameObject.SetActive(false);
        gameCam.gameObject.SetActive(true);
        DepositerPanelOpen = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}