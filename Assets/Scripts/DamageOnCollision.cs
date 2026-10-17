using UnityEngine;



public class DamageOnCollision : MonoBehaviour          // Add to anything that would cause damage if the ship ran into it (ground, wall, etc)
{
    public int damageAmount = 25;



    private void OnCollisionEnter(Collision collision)
    {
        ShipHealth shipHealth = collision.gameObject.GetComponent<ShipHealth>();        // gets the health of the object that got hit (ship), deals damage as long as the shipHealth is attached to it

        if (shipHealth != null)
        {
            shipHealth.TakeDamage(damageAmount);
        }
    }



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
