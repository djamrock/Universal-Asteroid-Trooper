using UnityEngine;





public class ShipHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;





    void Start()
    {
        currentHealth = maxHealth;      // Starting health is max health
    }




    public void TakeDamage(int damageAmount)
    {
        if (currentHealth <= 0)         // Checks to see if the ship already ran out of health, if so RETURN makes it stops taking damage 
        {
            return;
        }

        currentHealth -= damageAmount;

        if (currentHealth < 0)          // Prevents negative health
        {
            currentHealth = 0;
        }

        Debug.Log("Ship health: " + currentHealth);

        if (currentHealth == 0)         // When health reaches zero, looks for ShipDeath component of that game object (StarShipPawn)
        {
            ShipDeath death = GetComponent<ShipDeath>();

            if (death != null)          
            {
                death.Die();
            }
            else
            {
                Debug.Log("Ship health reached zero, but ShipDeath is missing.");
            }
        }
    }
}
