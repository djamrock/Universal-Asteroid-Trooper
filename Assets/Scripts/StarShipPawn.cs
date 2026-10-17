using Unity.VisualScripting;
using UnityEngine;



public class StarShipPawn : Pawn
{
    private Rigidbody rb;
    private Shooter sh;

    // Movement
    public float thrustForce = 10f;

    // Rotation
    public float yawSpeed= 5f;
    public float rollSpeed = 5f;
    public float pitchSpeed = 5f;


    public override void Start()
    {
        rb = GetComponent<Rigidbody>();
        sh = GetComponent<Shooter>();
    }

    public override void Update()
    {

    }

    public override void MoveForward()
    {
            rb.AddRelativeForce(Vector3.forward * thrustForce);
    }

    public override void MoveBackward()
    {
            rb.AddRelativeForce(Vector3.back * thrustForce);
    }

    public override void YawLeft()
    {
            transform.Rotate(0, -yawSpeed * Time.deltaTime, 0);
    }

    public override void YawRight()
    {
            transform.Rotate(0, yawSpeed * Time.deltaTime, 0);
    }

    public override void RollLeft()
    {
        transform.Rotate(0, 0, rollSpeed * Time.deltaTime);
    }

    public override void RollRight()
    {
            transform.Rotate(0, 0, -rollSpeed * Time.deltaTime);
    }

    public override void PitchUp()
    {
        transform.Rotate(-pitchSpeed * Time.deltaTime, 0, 0);
    }

    public override void PitchDown()
    {
        transform.Rotate(pitchSpeed * Time.deltaTime, 0, 0);
    }

    public override void Shoot()
    {
        if (sh != null)
        {
            sh.Shoot();
        }
    }
}
