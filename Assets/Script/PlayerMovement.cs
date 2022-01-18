using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody rigidBody;
    Animator animator;

    public Transform cam;
    public Transform groundCheck;

    [Header("Movement")]
    public float moveSpeed = 6f;
    float movementMuliplier = 10f;

    [Header("Rotation")]
    public float sensitivity = 10f;
    public float maxYAngle = 80f;
    private Vector2 currentRotation;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    [Header("Sprinting")]
    public float walkSpeed = 6f;
    public float acceleration = 10f;
    [SerializeField] float animSpeedControl = 1.5f;

    [Header("Jumping")]
    public float jumpForce = 5f;

    [Header("Keybinds")]
    [SerializeField] KeyCode jumpKey = KeyCode.Space;
    [SerializeField] KeyCode sprintKey = KeyCode.LeftShift;

    [Header("Ground Check")]
    bool isGrounded;
    float groundDistance = 0.8f;
    public LayerMask groundMask;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.freezeRotation = true;

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        float vertical = Input.GetAxisRaw("Vertical");
        float horizontal = Input.GetAxisRaw("Horizontal");

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        mouseY = Mathf.Clamp(mouseY, -maxYAngle, maxYAngle);
    
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;

        animator.SetBool("IsWalking", isWalking);

        Vector3 movePos = new Vector3(horizontal, 0f, vertical).normalized;
        
        currentRotation.x += mouseX * sensitivity;
        currentRotation.y -= mouseY * sensitivity;
        currentRotation.x = Mathf.Repeat(currentRotation.x, 360);
        currentRotation.y = Mathf.Clamp(currentRotation.y, -maxYAngle, maxYAngle);

        // cam.transform.rotation = Quaternion.Euler(currentRotation.y, currentRotation.x, 0f);
        transform.rotation = Quaternion.Euler(0f, currentRotation.x, 0f);

        // cam.transform.rotation = Quaternion.Euler(20f + currentRotation.y, currentRotation.x, 0f);
        // cam.Rotate(20f + mouseY, 0f, 0f);
        // cam.transform.rotation = Quaternion.Euler(currentRotation.y, cam.transofrm.x, 0f);

        // transform.rotation = Quaternion.Euler(0f, currentRotation.x, 0f);
        Vector3 moveDir = Quaternion.Euler(0f, currentRotation.x, 0f) * movePos;

        if (Input.GetKey(sprintKey) && isGrounded)
        {
            moveSpeed = acceleration;
            animSpeedControl = 2f;
        }
        else
        {
            moveSpeed = walkSpeed;
            animSpeedControl = 1.5f;
        }

        animator.SetFloat("WalkingSpeed", animSpeedControl);
        rigidBody.MovePosition(rigidBody.position + moveDir * Time.deltaTime * moveSpeed);
            
        if (Input.GetKey(jumpKey) && isGrounded)
        {
            rigidBody.velocity = new Vector3(rigidBody.velocity.x, jumpForce, rigidBody.velocity.z);
            //rigidBody.AddForce(transform.up * jumpForce, ForceMode.Impulse);
            animator.SetBool("IsJumping", true);
        }
        else
        {
            animator.SetBool("IsJumping", false);
        }
    }

    void LateUpdate()
    {
        cam.transform.rotation = Quaternion.Euler(currentRotation.y, currentRotation.x, 0f);
    }

}
