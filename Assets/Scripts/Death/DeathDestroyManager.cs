using UnityEngine;

public class DeathDestroyManager : Death
{
    public Animator animator;

    public int scoreValue;
    
    public Obstacle obstacleToRemoveOnDeath; // 
    public override void Die()
    {
        if (GameManager.instance != null) //make sure this instance exists
        {
            if (GameManager.instance.obstacleList != null && obstacleToRemoveOnDeath != null) // make sure obstacle list exists
            {
                GameManager.instance.obstacleList.Remove(obstacleToRemoveOnDeath); //
            }

            animator.SetTrigger("Explode");
            GameManager.instance.score += scoreValue;
        }

        Destroy(gameObject);
    }

    public override void Start()
    {
        animator = GetComponent<Animator>();
        obstacleToRemoveOnDeath = GetComponent<Obstacle>(); // 
    }

    public override void Update()
    {
        
    }

    public void DestroyAsteroid()
    {
        Destroy(gameObject);
    }

}
