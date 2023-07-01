using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    float horizontalInput;
    float verticalInput;
    Vector3 moveDirection;

    [Header("Objects & Components")]
    public Transform orientation;
    public Animator anim;
    Rigidbody rb;

    private UIEvents UIEvents;
    
    private const string RunAnim = "IsRunning";
    private const string IdleAnim = "IsIdle";

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        UIEvents = FindObjectOfType<UIEvents>();
    }

    private void Update()
    {
        MyInput();
        SpeedControl();
        AnimationSetup();

        if(UIEvents.FastSpeedUpgradeLevel == 1)
        {
            moveSpeed = UIEvents.MoveSpeedUpgradeIncreaseValueForLevel1;
        }

        if(UIEvents.FastSpeedUpgradeLevel == 2)
        {
            moveSpeed = UIEvents.MoveSpeedUpgradeIncreaseValueForLevel2;
        }

        if(UIEvents.FastSpeedUpgradeLevel == 3)
        {
            moveSpeed = UIEvents.MoveSpeedUpgradeIncreaseValueForLevel3;
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    private void MovePlayer()
    {
        // calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        //Adding movement force
        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        moveDirection = moveDirection.normalized;
    }

    private void SpeedControl()
    {
        //Setting up velocity config
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // limit velocity if needed
        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void AnimationSetup()
    {
        //Setting up animation
        //if player is pressing hor or ver key, playing run anim
        if(horizontalInput != 0 || verticalInput != 0)
        {
            anim.SetBool(RunAnim, true);
            anim.SetBool(IdleAnim, false);
        }
        //if player isn't pressing hor and ver key, playing idle anim
        else if(horizontalInput == 0 && verticalInput == 0)
        {
            anim.SetBool(RunAnim, false);
            anim.SetBool(IdleAnim, true);
        }
    }
}