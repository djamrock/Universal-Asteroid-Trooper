
using UnityEngine;
using UnityEngine.InputSystem;

public class GamepadController : MonoBehaviour
{
    public PlayerController playerController;
    public CameraFollow cameraFollow;

    public float stickDeadzone = 0.2f;

    private Gamepad gamepad;

    void Update()
    {
        gamepad = Gamepad.current;

        if (gamepad == null || playerController == null)
        {
            return;
        }

        // Left stick vertical: forward and backward
        float moveInput = gamepad.rightStick.ReadValue().y;

        if (moveInput > stickDeadzone)
        {
            playerController.pawn.MoveForward();
        }

        if (moveInput < -stickDeadzone)
        {
            playerController.pawn.MoveBackward();
        }

        // Left stick horizontal: roll left and right
        float rollInput = gamepad.leftStick.ReadValue().x;

        if (rollInput < -stickDeadzone)
        {
            playerController.pawn.RollLeft();
        }

        if (rollInput > stickDeadzone)
        {
            playerController.pawn.RollRight();
        }

        // Right stick vertical: pitch
        float pitchInput = gamepad.leftStick.ReadValue().y;

        if (pitchInput > stickDeadzone)
        {
            playerController.pawn.PitchDown();
        }

        if (pitchInput < -stickDeadzone)
        {
            playerController.pawn.PitchUp();
        }

        // Bumpers: yaw
        if (gamepad.leftShoulder.isPressed)
        {
            playerController.pawn.YawLeft();
        }

        if (gamepad.rightShoulder.isPressed)
        {
            playerController.pawn.YawRight();
        }

        // Right trigger: shoot
        if (gamepad.rightTrigger.wasPressedThisFrame)
        {
            playerController.pawn.Shoot();
        }

        // D-pad: camera distance
        if (cameraFollow != null)
        {
            if (gamepad.dpad.up.wasPressedThisFrame)
            {
                cameraFollow.ChangeDistance(-1f);
            }

            if (gamepad.dpad.down.wasPressedThisFrame)
            {
                cameraFollow.ChangeDistance(1f);
            }
        }
    }
}
