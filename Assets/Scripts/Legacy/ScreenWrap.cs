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
        if (mainCamera == null)                                                 // Finds camera and Rigidbody, checks objects screen position every frame, if object is outside limits, changes screen position to other 
        {                                                                       // side, converts back to world coordinates
            return;
        }

        Vector3 screenPosition = mainCamera.WorldToViewportPoint(transform.position);   // Get the objects position in game world, converts it to screen position
        bool needsWrapping = false;

        if (screenPosition.x > 1f)                   // Wrap left and right
        {
            screenPosition.x = 0f;
            needsWrapping = true;
        }

        else if (screenPosition.x < 0f)
        {
            screenPosition.x = 1f;
            needsWrapping = true;
        }

        if (screenPosition.y > 1f)                          // Wrap top and bottom
        {
            screenPosition.y = bottomWrapBoundary;
            needsWrapping = true;
        }

        else if (screenPosition.y < bottomWrapBoundary)
        {
            screenPosition.y = 1f;
            needsWrapping = true;
        }
        
        if (needsWrapping)                                                  // Only change position if the object is outside of the screen
        {
            Vector3 newPosition = mainCamera.ViewportToWorldPoint(screenPosition);       // Convert the position back into the game world

            if (rb != null)                                                 // Move the object to the new position
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
