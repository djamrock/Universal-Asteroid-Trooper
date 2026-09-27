using UnityEngine;

public class DeathDestroyManager : Death
{
    public Obstacle obstacleToRemoveOnDeath; // 
    public override void Die()
    {
        if (GameManager.instance != null) //make sure this instance exists
        {
            if (GameManager.instance.obstacleList != null && obstacleToRemoveOnDeath != null) // make sure obstacle list exists
            {
                GameManager.instance.obstacleList.Remove(obstacleToRemoveOnDeath); //
            }
        }

        Destroy(gameObject);
    }

    public override void Start()
    {
        obstacleToRemoveOnDeath = GetComponent<Obstacle>(); // 
    }

    public override void Update()
    {
        
    }

}
