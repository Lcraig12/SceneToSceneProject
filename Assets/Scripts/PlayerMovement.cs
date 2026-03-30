using UnityEngine;

public class TestPlayerMove : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;     // Normal walking speed
    public float sprintSpeed = 8f;    // Running speed when sprinting
    public float rotationSpeed = 10f; // How fast character turns to face movement direction
    public float jumpForce = 8f;      // How high character jumps
    
    [Header("Ground Detection")]
    public float groundCheckDistance = 0.3f; // Distance to check for ground
    public LayerMask groundMask;            // Which layers count as ground
    
    [Header("Camera")]
    public Transform cameraTransform;        // Reference to the camera
    
    // Private variables
    private CharacterController controller;  // Unity's character controller
    private Transform playerTransform;       // Reference to player's transform
    private Vector3 moveDirection;           // Current movement direction
    private float currentSpeed;              // Current movement speed
    private bool isGrounded;                 // Is the character on the ground?
    private float verticalVelocity;          // Vertical speed (for jumping/falling)
    private float gravity = -9.81f;          // Gravity strength
    
    void Start()
    {
        // Get component references
        controller = GetComponent<CharacterController>();
        playerTransform = transform;
        currentSpeed = moveSpeed;  // Start with normal speed
    }
    
    void Update()
    {
        // Ground check using a sphere cast at player's feet
        /*
        isGrounded = Physics.CheckSphere(
            transform.position + Vector3.down * controller.height/2, 
            groundCheckDistance 
            //groundMask
        );
        */
        
        isGrounded = controller.isGrounded;
        // Reset vertical velocity when grounded to prevent accumulation
        if (isGrounded && verticalVelocity < 0)
        {
            verticalVelocity = -2f;  // Small negative value for better grounding
        }
        
        // Get keyboard movement input
        float horizontal = Input.GetAxis("Horizontal");  // A/D keys or left/right arrows
        float vertical = Input.GetAxis("Vertical");      // W/S keys or up/down arrows
        
        // Set speed based on sprint input (shift key)
        currentSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : moveSpeed;
        
        // Calculate movement direction relative to camera
        Vector3 forward = cameraTransform.forward;  // Camera's forward direction
        Vector3 right = cameraTransform.right;      // Camera's right direction
        
        // Project forward and right vectors on the horizontal plane (remove y component)
        forward.y = 0;
        right.y = 0;
        forward.Normalize();  // Ensure vector length is 1
        right.Normalize();    // Ensure vector length is 1
        
        // Calculate the move direction in world space based on camera orientation
        // This creates camera-relative movement (forward is camera forward, not world forward)
        moveDirection = forward * vertical + right * horizontal;
        
        // Normalize movement vector to prevent faster diagonal movement
        if (moveDirection.magnitude > 1f)
        {
            moveDirection.Normalize();  // Make vector length 1
        }
        
        // Apply movement using character controller
        controller.Move(moveDirection * currentSpeed * Time.deltaTime);
        
        // Rotate player to face movement direction
        if (moveDirection != Vector3.zero)
        {
            // Create rotation that looks in movement direction
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            
            // Smoothly rotate from current to target rotation
            playerTransform.rotation = Quaternion.Slerp(
                playerTransform.rotation, 
                targetRotation, 
                rotationSpeed * Time.deltaTime
            );
        }
        
        // Jump when space is pressed and grounded
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            verticalVelocity = jumpForce;  // Set upward velocity
        }
        
        // Apply gravity to vertical velocity
        verticalVelocity += gravity * Time.deltaTime;
        
        // Apply vertical movement (jumping/falling)
        controller.Move(Vector3.up * verticalVelocity * Time.deltaTime);
    }
    /*
    void OnDrawGizmosSelected()
    {
        // Draw ground check sphere in Scene view for debugging
        Gizmos.color = isGrounded ? Color.green : Color.red;
        Vector3 groundCheckPos = transform.position + Vector3.down * controller.height/2;
        Gizmos.DrawWireSphere(groundCheckPos, groundCheckDistance);
    }
    */
}