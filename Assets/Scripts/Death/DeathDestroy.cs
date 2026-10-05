using UnityEngine;

public class DeathDestroy : Death  // DeathDestroy class inherets from Death component
{
    public override void Die()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.PlayFailureSound();    // adds game over sound, the 2f below delays the pawn from being destroyed until after its played
        }

        Destroy(gameObject, 2f); // gameObject refers to the game object that this DeathDestoy Component is attached to
    }

    public override void Start()
    {
        
    }

    public override void Update()
    {
        
    }

}
