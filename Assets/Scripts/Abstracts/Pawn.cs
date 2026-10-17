using UnityEngine;


// This script is essentially a blueprint, explains what a Pawn must be capable of doing. Any different type of pawn would define what each of these mean in their own script.
// Local movement is based on the pawn orientation (up is forward), World movement is based on the game worlds fixed direction (up is positive Y)


public abstract class Pawn : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public abstract void Start(); 

    // Update is called once per frame
    public abstract void Update();

    public abstract void MoveForward();

    public abstract void MoveBackward();

    public abstract void YawLeft();

    public abstract void YawRight();

    public abstract void RollLeft();

    public abstract void RollRight();

    public abstract void PitchUp();

    public abstract void PitchDown();

    public abstract void Shoot();


}
