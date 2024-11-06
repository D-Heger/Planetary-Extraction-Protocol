using UnityEngine;

public class Player : MonoBehaviour
{
    public float MoveSpeed = 5.0f;
    public Rigidbody2D Rigidbody2D;

    void Update()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        float horizontal = Input.GetAxis("Horizontal") * MoveSpeed;
        float vertical = Input.GetAxis("Vertical") * MoveSpeed;
        
        Rigidbody2D.velocity = new Vector2(horizontal, vertical);
    }
}
