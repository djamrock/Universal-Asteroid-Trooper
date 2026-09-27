using UnityEngine;

public class DeathPawn : Death
{
    public Controller controller;

    public override void Die()
    {
        if (controller != null)
        {
            controller.pawn = null;
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
