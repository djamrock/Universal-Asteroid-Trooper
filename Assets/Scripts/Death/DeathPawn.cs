using UnityEngine;

public class DeathPawn : Death
{
    public Controller controller;

    public AudioClip deathSound;

    public override void Die()
    {
        if (deathSound != null)
        {
            AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position);
        }

        Debug.Log("DeathPawn was called");
        if (GameManager.instance != null)
        {
            if (GameManager.instance.playerLives != null)
            {
                GameManager.instance.playerLives.HandlePlayerDeath();
            }
        }

        Destroy(gameObject);
    }

    public override void Start()
    {
        controller = GetComponent<Controller>();
    }

    public override void Update()
    {
       
    }

   
}
