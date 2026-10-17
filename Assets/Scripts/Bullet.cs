using UnityEngine;



public class Bullet : MonoBehaviour
{
    
    public float fireForce;

    public Rigidbody rb;

    public float lifetime = 3f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (rb != null) // if Rigidbody2D component exist
        {
            rb.AddForce(transform.forward * fireForce); // Applying forward force to the bullet (positive Z axis)
        }
        else
        {
            Debug.Log("Bullet needs a Rigidbody!");
        }

        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
