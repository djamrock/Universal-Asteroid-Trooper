using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float currentHealth;

    public float maxHealth;

    private Death death;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        death = GetComponent<Death>(); // if component exists, that is saved in the variable. if it doesnt exist, null is saved
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Heal(float healAmount)
    {
        currentHealth += healAmount;

        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // if current health is between zero and max, clamp returns current. If current is less than zero, clamp returns zero. If current health is greater than max, max is returned.
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;

        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        if (currentHealth <= 0 && death != null)
        {
            // Die
            death.Die();
        }
    }
}
