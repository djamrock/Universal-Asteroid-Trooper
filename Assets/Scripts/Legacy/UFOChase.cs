using UnityEngine;

public class UFOChase : MonoBehaviour
{
    public float moveSpeed = 2f;
    private Rigidbody2D rb;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.Log("UFOChase requires a Rigidbody2D");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance == null)
        {
            return;
        }

        if (GameManager.instance.playerController == null)
        {
            return;
        }

        if (GameManager.instance.playerController.pawn == null)
        {
            return;
        }

        // Get players position
        Transform player = GameManager.instance.playerController.pawn.transform;

        // Calculate direction toward player
        Vector2 direction = (Vector2)player.position - rb.position;

        // Make sure UFO has a direction to move
        if (direction.magnitude < 0.01f)        // Direction store which way the UFO has to travel towards player, Magnitude is how far
        {                                       // Magnitude works using pythagorean theorem, if direction is (x 3,y 4), magnitude is 5 (a^2 + b^2 = c^2)
            return;
        }

        // Make the direction length equal to 1
        direction.Normalize();

        // Move the UFO toward the player
        rb.MovePosition(rb.position + direction * moveSpeed * Time.deltaTime);

    }
}
