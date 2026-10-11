using UnityEngine;

public class ScreenWrap : MonoBehaviour
{
    public Camera mainCamera;
    private Rigidbody2D rb;

    public float bottomWrapBoundary = 0.15f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mainCamera == null)
        {
            return;
        }

        Vector3 screenPosition = mainCamera.WorldToViewportPoint(transform.position);   // Get the objects position on the screen
        bool needsWrapping = false;

        // Wrap left and right
        if (screenPosition.x > 1f)
        {
            screenPosition.x = 0f;
            needsWrapping = true;
        }

        else if (screenPosition.x < 0f)
        {
            screenPosition.x = 1f;
            needsWrapping = true;
        }

        // Wrap top and bottom
        if (screenPosition.y > 1f)
        {
            screenPosition.y = bottomWrapBoundary;
            needsWrapping = true;
        }

        else if (screenPosition.y < bottomWrapBoundary)
        {
            screenPosition.y = 1f;
            needsWrapping = true;
        }
        
        // Only change position if the object is outside of the screen
        if (needsWrapping)
        {
            // Convert the position back into the game world
            Vector3 newPosition = mainCamera.ViewportToWorldPoint(screenPosition);

            // Move the object to the new position
            if (rb != null)
            {
                rb.position = new Vector2(newPosition.x, newPosition.y);
            }

            else
            {
                transform.position = newPosition;
            }
        }
    }
}
