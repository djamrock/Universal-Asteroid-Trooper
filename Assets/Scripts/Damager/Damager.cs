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

    private void OnTriggerEnter2D(Collider2D collision)  // gets the info about other object being collided with, can see if it has a health component, executes damage function if so
    {
        otherHealthComponent = collision.GetComponent<Health>(); // (Collider 2D collision) parameter contains info about the other object being collided with, so GetComponent will access its Health component

        if (otherHealthComponent != null) // checks to see if the other health component exists
        {
            if (isInstaKill)
            {
                otherHealthComponent.TakeDamage(otherHealthComponent.maxHealth); // if instakill is set to true, uses the other components max health damage, otherwise it goes to damageAmount thats set in inspector
            }
            else
            {
                otherHealthComponent.TakeDamage(damageAmount);  // uses Encapsulation because this script does change the health directly, it calls the health component for the other object instead of being written like "otherHealthComponent.currentHealth -= damageAmount". This also adds into Abstraction, Damager script doesnt know everything that goes into objects taking damage, it just uses the TakeDamage method that is already built in the Health script.
            }
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)  // gets the info about other object being collided with, can see if it has a health component, executes damage function if so
    {
        Debug.Log("COLLISION DETECTED");

        otherHealthComponent = collision.gameObject.GetComponent<Health>(); // (Collider 2D collision) parameter contains info about the other object being collided with, so GetComponent will access its Health component

        if (otherHealthComponent != null) // checks to see if the other health component exists
        {
            if (isInstaKill)
            {
                otherHealthComponent.TakeDamage(otherHealthComponent.maxHealth); // if instakill is set to true, uses the other components max health damage, otherwise it goes to damageAmount thats set in inspector
            }
            else
            {
                otherHealthComponent.TakeDamage(damageAmount);
            }
            //Destroy(gameObject);
        }
    }
}
