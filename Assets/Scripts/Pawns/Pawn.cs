using UnityEngine;


// This script is essentially a blueprint, explains what a Pawn must be capable of doing. Any different type of pawn would define what each of these mean in their own script.
// Local movement is based on the pawn orientation (up is forward), World movement is based on the game worlds fixed direction (up is positive Y)


public abstract class Pawn : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public abstract void Start(); 

    // Update is called once per frame
    public abstract void Update();

    public abstract void Teleport();

    public abstract void Quit();

    public abstract void MoveForwardLocal();

    public abstract void MoveBackwardLocal();

    public abstract void RotateClockwise();

    public abstract void RotateCounterClockwise();

    public abstract void MoveForwardLocalTurbo();

    public abstract void MoveBackwardLocalTurbo();

    public abstract void RotateClockwiseTurbo();

    public abstract void RotateCounterClockwiseTurbo();

    public abstract void MoveForwardWorld();

    public abstract void MoveBackwardWorld();

    public abstract void MoveRightWorld();

    public abstract void MoveLeftWorld();


}
