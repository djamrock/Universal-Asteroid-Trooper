using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    public float moveSpeed = 0.5f;
    private Vector2 moveDirection;
    private Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        moveDirection = Random.insideUnitCircle;         // picks a random direction

        // Make sure the direction is not zero
        if (moveDirection.magnitude < 0.001f)
        {
            moveDirection = Vector2.right;
        }

        // Make the direction length equal to 1
        moveDirection.Normalize();
    }

    void Update()
    {
        // Move the asteroid in its random direction
        rb.MovePosition(
            rb.position + moveDirection * moveSpeed * Time.deltaTime
        );
    }
}
