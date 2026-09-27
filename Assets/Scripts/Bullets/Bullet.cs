using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    public float fireForce;

    public Rigidbody2D rb;

    public Transform tf;

    public float lifetime;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        tf = GetComponent<Transform>();

        if (rb != null && tf != null) // if Rigidbody2D and Transform component exist
        {
            rb.AddForce(tf.up * fireForce); // Applying force to the bullet
        }

        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
