using UnityEngine;

public class DeathDestroyManager : Death
{
    public Animator animator;

    public int scoreValue;
    
    public Obstacle obstacleToRemoveOnDeath;

    public AudioClip explosionSound;

    public AudioSource audioSource;


    public override void Die()
    {
        if (GameManager.instance != null) //make sure this instance exists
        {
            if (GameManager.instance.obstacleList != null && obstacleToRemoveOnDeath != null) // make sure obstacle list exists
            {
                GameManager.instance.obstacleList.Remove(obstacleToRemoveOnDeath); 
            }

            Health health = GetComponent<Health>(); // This makes the health bar disappear immediately so its doesnt block the view of the explosion

            if (health != null && health.healthBar != null)
            {
                health.healthBar.gameObject.SetActive(false);
            }

            if (explosionSound != null && audioSource != null)      // adds explosion sound when destroyed
            {
                audioSource.PlayOneShot(explosionSound);
            }

            animator.SetTrigger("Explode");  // animation I added for the Asteroid to expode 

            GameManager.instance.score += scoreValue;
        }

    }

    public override void Start()
    {
        animator = GetComponent<Animator>();
        obstacleToRemoveOnDeath = GetComponent<Obstacle>();
        audioSource = GetComponent<AudioSource>();
    }

    public override void Update()
    {
        
    }

    public void DestroyAsteroid()
    {
        Destroy(gameObject);
    }

}
