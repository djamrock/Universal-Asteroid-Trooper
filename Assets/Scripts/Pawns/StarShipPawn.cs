using UnityEngine;


// This script explains each movement for this specific type of pawn that Pawn.cs requires. If another type of pawn was created, it would have its own script so these movements could be different (ship, tank, truck etc would all use the functions from Pawn.cs, but would act differently due to their own scripts)


public class StarShipPawn : Pawn
{
    public float minX;

    public float maxX;

    public float minY;

    public float maxY;

    public Transform tf;

    public float normalSpeed;

    public float turboSpeed;

    public float normalRotateSpeed;

    public float turboRotateSpeed;


    public override void MoveBackwardLocal()
    {
        tf.position = tf.position + tf.up * -normalSpeed * Time.deltaTime;
    }

    public override void MoveBackwardLocalTurbo()
    {
        tf.position = tf.position + tf.up * -turboSpeed * Time.deltaTime;
    }

    public override void MoveBackwardWorld()
    {
        tf.position = tf.position + -Vector3.up;
    }

    public override void MoveForwardLocal()
    {
        tf.position = tf.position + tf.up * normalSpeed * Time.deltaTime;
    }

    public override void MoveForwardLocalTurbo()
    {
        tf.position = tf.position + tf.up * turboSpeed * Time.deltaTime;
    }

    public override void MoveForwardWorld()
    {
        tf.position = tf.position + Vector3.up;
    }

    public override void MoveLeftWorld()
    {
        tf.position = tf.position + -Vector3.right;
    }

    public override void MoveRightWorld()
    {
        tf.position = tf.position + Vector3.right;
    }

    public override void RotateClockwise()
    {
        tf.Rotate(0, 0, normalRotateSpeed * -Time.deltaTime);
    }

    public override void RotateClockwiseTurbo()
    {
        tf.Rotate(0, 0, turboRotateSpeed * -Time.deltaTime);
    }

    public override void RotateCounterClockwise()
    {
        tf.Rotate(0, 0, normalRotateSpeed * Time.deltaTime);
    }

    public override void RotateCounterClockwiseTurbo()
    {
        tf.Rotate(0, 0, turboRotateSpeed * Time.deltaTime);
    }

    public override void Teleport()
    {
        tf.position = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY));
    }

    public override void Quit()
    {
        Application.Quit();
    }

    public override void Start()
    {
        tf = GetComponent<Transform>();
    }

    public override void Update()
    {
        
    }

}


