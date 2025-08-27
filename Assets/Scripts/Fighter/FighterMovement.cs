using UnityEngine;
using UnityEngine.InputSystem;

public class FighterMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;

    [Header("Optional - Boundaries")]
    public bool useBoundaries = true;
    public float leftBoundary = -4f;
    public float rightBoundary = 4f;
    public float topBoundary = 1f;
    public float bottomBoundary = -4f;

    // Private variables
    private Vector2 movement;
    private Rigidbody2D rb;

    // void Start()
    // {
    //     // Get the Rigidbody2D component
    //     rb = GetComponent<Rigidbody2D>();

    //     // If no Rigidbody2D exists, add one
    //     if (rb == null)
    //     {
    //         rb = gameObject.AddComponent<Rigidbody2D>();
    //         rb.gravityScale = 0f; // No gravity for top-down movement
    //     }
    // }

    void Update()
    {
        // Get input using new Input System
        Vector2 inputVector = Vector2.zero;

        // Check for WASD and Arrow Keys manually
        if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed)
            inputVector.y = 1f;
        if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed)
            inputVector.y = -1f;
        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
            inputVector.x = -1f;
        if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
            inputVector.x = 1f;

        // Create movement vector
        movement = inputVector;

        // Optional: Normalize diagonal movement so it's not faster
        if (movement.magnitude > 1)
        {
            movement = movement.normalized;
        }

        // Debug info
        if (movement != Vector2.zero)
        {
            Debug.Log("Moving: " + movement);
        }
    }

    void FixedUpdate()
    {
        // Move the fighter using physics
        Vector2 newPosition = rb.position + movement * moveSpeed * Time.fixedDeltaTime;

        // Apply boundaries if enabled
        if (useBoundaries)
        {
            newPosition.x = Mathf.Clamp(newPosition.x, leftBoundary, rightBoundary);
            newPosition.y = Mathf.Clamp(newPosition.y, bottomBoundary, topBoundary);
        }

        // Apply the movement
        rb.MovePosition(newPosition);
    }

    // Optional: Visual feedback in Scene view for boundaries
    void OnDrawGizmosSelected()
    {
        if (useBoundaries)
        {
            Gizmos.color = Color.yellow;
            Vector3 size = new Vector3(rightBoundary - leftBoundary, topBoundary - bottomBoundary, 0);
            Vector3 center = new Vector3((rightBoundary + leftBoundary) / 2, (topBoundary + bottomBoundary) / 2, 0);
            Gizmos.DrawWireCube(center, size);
        }
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody2D>();
        }

        rb.gravityScale = 0f; // no gravity in top-down
        rb.bodyType = RigidbodyType2D.Dynamic; // allow movement
        rb.freezeRotation = true; // prevent unwanted spinning
    }

}

