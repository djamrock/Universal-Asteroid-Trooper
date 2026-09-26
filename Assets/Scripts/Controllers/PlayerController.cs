using UnityEngine;


// This script takes user input and decides what command to send


public class PlayerController : Controller
{
    public KeyCode teleportKey;

    // The following 4 keys are for local movement
    // W
    public KeyCode moveForwardLocal;
    // S
    public KeyCode moveBackwardLocal;
    // D
    public KeyCode rotateClockwise;
    // A
    public KeyCode rotateCounterClockwise;

    // The following 4 keys are for world movement
    // Up Arrow
    public KeyCode moveForwardWorld;
    // Down Arrow
    public KeyCode moveBackwardWorld;
    // Right Arrow
    public KeyCode moveRightWorld;
    // Left Arrow
    public KeyCode moveLeftWorld;

    // Turbos
    // Left Shift
    public KeyCode turboOption1;
    // Right Shift
    public KeyCode turboOption2;

    //Quit
    public KeyCode quitKey;

    public override void MakeDecisions()  // This is all of the player movement
    {
        if (Input.GetKey(turboOption1) || Input.GetKey(turboOption2))
        {
            // Speed boost
            if (Input.GetKey(moveForwardLocal))
            {
                pawn.MoveForwardLocalTurbo();
            }
            if (Input.GetKey(moveBackwardLocal))
            {
                pawn.MoveBackwardLocalTurbo();
            }
            if (Input.GetKey(rotateClockwise))
            {
                pawn.RotateClockwiseTurbo();
            }
            if (Input.GetKey(rotateCounterClockwise))
            {
                pawn.RotateCounterClockwiseTurbo();
            }
        }
        else
        {
            // Normal speed
            if (Input.GetKey(moveForwardLocal))
            {
                pawn.MoveForwardLocal();
            }
            if (Input.GetKey(moveBackwardLocal))
            {
                pawn.MoveBackwardLocal();
            }
            if (Input.GetKey(rotateClockwise))
            {
                pawn.RotateClockwise();
            }
            if (Input.GetKey(rotateCounterClockwise))
            {
                pawn.RotateCounterClockwise();
            }
        }


        // Worldspace
        if (Input.GetKeyDown(moveForwardWorld))
        {
            pawn.MoveForwardWorld();
        }
        if (Input.GetKeyDown(moveBackwardWorld))
        {
            pawn.MoveBackwardWorld();
        }
        if (Input.GetKeyDown(moveRightWorld))
        {
            pawn.MoveRightWorld();
        }
        if (Input.GetKeyDown(moveLeftWorld))
        {
            pawn.MoveLeftWorld();
        }

        //Teleportation
        if (Input.GetKeyDown(teleportKey))
        {
            pawn.Teleport();
        }

        //Quit
        if (Input.GetKeyDown(quitKey))
        {
            pawn.Quit(); 
        }
    }

    public override void Start()
    {
        
    }

    public override void Update()
    {
        MakeDecisions();
    }


}
