using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float currentHealth;

    public float maxHealth;

    public Death death;

    public Image healthBar;

    public AudioClip hitSound;

    public AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        death = GetComponent<Death>(); // if component exists, that is saved in the variable. if it doesnt exist, null is saved
        audioSource = GetComponent<AudioSource>();

        if (healthBar != null)
        {
            healthBar.fillAmount = 1f - (currentHealth / maxHealth);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Heal(float healAmount)
    {
        currentHealth += healAmount;

        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // if current health is between zero and max, clamp returns current. If current is less than zero, clamp returns zero. If current health is greater than max, max is returned.

        if (healthBar != null)
        {
            healthBar.fillAmount = 1f - (currentHealth / maxHealth);
        }
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;

        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        if (healthBar != null)
        {
            healthBar.fillAmount = 1f - (currentHealth / maxHealth);
        }

        if (hitSound != null && audioSource != null)    // adds sound to taking damage
        {
            audioSource.PlayOneShot(hitSound);
        }

        if (currentHealth <= 0 && death != null) // both conditions must be true, current health zero or less, and death isnt null
        {
            // Die
            death.Die();
        }
    }
}
