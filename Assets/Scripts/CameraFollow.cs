using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    // Target
    public Transform target;                    // Object the camera follows (assign ship in Inspector)

    // Camera Offset
    private Vector3 offsetDirection = new Vector3(0f, 0.5f, -1f);        // direction from the ship the camera sits
    public float offsetDistance = 10f;                                  // distance
    public float minDistance = 5f;
    public float maxDistance = 25f;
    public float distanceChangeSpeed = 5f;

    // Look At
    public Vector3 lookAtOffset = new Vector3(0f, 0f, 5f);      // Sets a point 5 units ahead of the target (target gets the ship assigned in Inspector)

    // Smoothing
    public float followSmoothSpeed = 5f;


    private void LateUpdate()                   // LateUpdate runs after Update, so after ship is moved the camera can then use the new location
    {
        // Change camera distance
        if (Input.GetKey(KeyCode.O))
        {
            offsetDistance += distanceChangeSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.L))
        {
            offsetDistance -= distanceChangeSpeed * Time.deltaTime;
        }

        // Set limits
        offsetDistance = Mathf.Clamp(offsetDistance, minDistance, maxDistance);         // min/max distances camera can be set to

        // Get camera direction relative to the ship
        Vector3 direction = target.TransformDirection(offsetDirection.normalized);      // (makes offset direction length 1), converts the direction from the ships local position to world space

        // Calculate desired position
        Vector3 desiredPosition = target.position + direction * offsetDistance;         // starship position + (camera direction determined above * the set offset distance)


        // Smooth Follow
                                  // Lerp (starting poistion, target position, amount)
        transform.position = Vector3.Lerp(transform.position, desiredPosition, followSmoothSpeed * Time.deltaTime);  // moves camera towards desiredPosition from current position gradually instead of all in 1 frame

        // Calculate point to look at
        Vector3 lookAtPoint = target.position + target.TransformDirection(lookAtOffset);    // converts offset to a world direction, adds it to the ships position


        // Point camera
        transform.LookAt(lookAtPoint);      // rotates camera to that point

    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeDistance(float amount)        // added only for gamepad to change the camera offset distance
    {
        offsetDistance += amount;

        offsetDistance = Mathf.Clamp(offsetDistance, minDistance, maxDistance);
    }

}
