using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5.0f;

    void Update()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(horizontal, vertical) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);
    }
}
