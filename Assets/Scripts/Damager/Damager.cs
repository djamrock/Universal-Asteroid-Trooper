using UnityEngine;

public class Damager : MonoBehaviour
{
    public float damageAmount;

    public bool isInstaKill;

    public Health otherHealthComponent;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)  // gets the info about other object being collided with, can see if it has a health component, executed damage function if so
    {
        otherHealthComponent = collision.GetComponent<Health>(); // (Collider 2D collision) parameter contains info about the other object being collided with, so GetComponent will access its Health component

        if (otherHealthComponent != null) // checks to see if the other health componet exists
        {
            if (isInstaKill)
            {
                otherHealthComponent.TakeDamage(otherHealthComponent.maxHealth); // if instakill is set to true, uses the other components max health damage, otherwise it goes to damageAmount thats set in inspector
            }
            else
            {
                otherHealthComponent.TakeDamage(damageAmount);
            }
            Destroy(gameObject);
        }
    }
}
