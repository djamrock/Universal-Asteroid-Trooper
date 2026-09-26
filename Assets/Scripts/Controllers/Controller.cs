using UnityEngine;


// This script defines what a controller must be able to do, blueprint for things that control Pawns. Currently PlayerController is the only type of controller, but if others were created, like AIController, it would have its own script explaining its own movement in MakeDecisions 


public abstract class Controller : MonoBehaviour
{
    public Pawn pawn;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public abstract void Start();

    // Update is called once per frame
    public abstract void Update();

    public abstract void MakeDecisions();
}
