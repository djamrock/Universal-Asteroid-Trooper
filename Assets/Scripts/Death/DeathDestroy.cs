using UnityEngine;

public class DeathDestroy : Death  // DeathDestroy class inherets from Death component
{
    public override void Die()
    {
        Destroy(gameObject); // gameObject refers to the game object that this DeathDestoy Component is attached to
    }

    public override void Start()
    {
        
    }

    public override void Update()
    {
        
    }

}
