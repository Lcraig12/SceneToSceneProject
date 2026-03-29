using UnityEngine;

public class TestCamera : MonoBehaviour
{
    public Transform target;               // Player character to follow
    public float distance = 5f;            // Distance from camera to player
    public float height = 2f;              // Height offset of camera
    public float smoothSpeed = 10f;        // How smoothly camera follows player
    public float rotationSmoothSpeed = 5f; // How smoothly camera rotates
    
    // Mouse input settings
    public float mouseSensitivity = 100f;  // Mouse sensitivity for camera rotation
    public bool invertY = false;           // Whether to invert vertical mouse
    
    // Collision settings
    public float minDistance = 1f;         // Minimum camera distance (for collision)
    public LayerMask collisionMask;        // Which layers block camera
    
    // Private variables
    private float currentRotationX = 0f;   // Current horizontal rotation
    private float currentRotationY = 0f;   // Current vertical rotation
    private Vector3 currentRotation;       // Combined rotation vector
    private Vector3 smoothVelocity = Vector3.zero; // For smooth damping
    
    void Start()
    {
        // Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
        // Initial rotation based on target
        Vector3 angles = transform.eulerAngles;
        currentRotationX = angles.y;
        currentRotationY = angles.x;
    }
    
    void LateUpdate()
    {
        if (target == null) return;
        
        // Mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        
        // Adjust rotation based on mouse input
        currentRotationX += mouseX;
        currentRotationY += (invertY ? 1 : -1) * mouseY;
        currentRotationY = Mathf.Clamp(currentRotationY, -60f, 60f);
        
        // Calculate desired rotation
        currentRotation = Vector3.SmoothDamp(
            currentRotation, 
            new Vector3(currentRotationY, currentRotationX, 0), 
            ref smoothVelocity, 
            1f / rotationSmoothSpeed
        );
        
        // Convert to quaternion
        Quaternion rotation = Quaternion.Euler(currentRotation);
        
        // Calculate camera position
        Vector3 targetPosition = target.position + Vector3.up * height;
        Vector3 direction = rotation * Vector3.back;
        float targetDistance = distance;
        
        // Camera collision detection
        RaycastHit hit;
        if (Physics.Raycast(targetPosition, direction, out hit, distance, collisionMask))
        {
            targetDistance = Mathf.Clamp(hit.distance, minDistance, distance);
        }
        
        // Set camera position and rotation
        transform.position = targetPosition + direction * targetDistance;
        transform.rotation = rotation;
    }
}