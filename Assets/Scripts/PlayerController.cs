using UnityEngine;


public class PlayerController : Controller
{

    //// W
    //public KeyCode moveForward;
    //// S
    //public KeyCode moveBackward;

    //public KeyCode yawLeft();

    //public abstract void YawRight();

    //public abstract void RollLeft();

    //public abstract void RollRight();

    //public abstract void PitchUp();

    //public abstract void PitchDown();

    //Shoot
    public KeyCode shootKey;

    public override void MakeDecisions()  // This is all of the player movement
    {
        if (pawn == null)
        {
            return;
        }

        // Forward and backward movement
        if (Input.GetKey(KeyCode.W))
        {
            pawn.MoveForward();
        }

        if (Input.GetKey(KeyCode.S))
        {
            pawn.MoveBackward();
        }

        // Yaw: turn left and right
        if (Input.GetKey(KeyCode.A))
        {
            pawn.YawLeft();
        }

        if (Input.GetKey(KeyCode.D))
        {
            pawn.YawRight();
        }

        // Roll
        if (Input.GetKey(KeyCode.Q))
        {
            pawn.RollLeft();
        }

        if (Input.GetKey(KeyCode.E))
        {
            pawn.RollRight();
        }

        // Pitch
        if (Input.GetKey(KeyCode.Z))
        {
            pawn.PitchUp();
        }

        if (Input.GetKey(KeyCode.X))
        {
            pawn.PitchDown();
        }

        // Shoot once when the shoot key is pressed
        if (Input.GetKeyDown(shootKey))
        {
            pawn.Shoot();
        }

    }

    public override void Start()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.playerController = this; // playerController is registering itself with the GameManager
        }
    }

    public override void Update()
    {
        MakeDecisions();
    }
}

