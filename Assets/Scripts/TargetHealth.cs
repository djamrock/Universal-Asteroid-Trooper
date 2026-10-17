using UnityEngine;



public class TargetHealth : MonoBehaviour
{

    public int maxHealth = 1;
    private int currentHealth;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;    
    }



    public void TakeDamage(int damageAmount)        // subtracts the damage amount from the current health, makes that the new current health. Destroys if health is zero or less
    {
        currentHealth -= damageAmount;

        Debug.Log(gameObject.name + " health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
