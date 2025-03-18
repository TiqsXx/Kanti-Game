using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of the player movement
    public Rigidbody rb; // Reference to the Rigidbody component

    private Vector3 movement; // Stores the movement input
    
    void Update()
    {
        // Input handling
        movement.x = Input.GetAxisRaw("Horizontal"); // A/D or Left/Right Arrow
        movement.z = Input.GetAxisRaw("Vertical");   // W/S or Up/Down Arrow
    }

    void FixedUpdate()
    {
        // Movement logic
        Vector3 moveDirection = movement.normalized * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + moveDirection);
    }
    
}