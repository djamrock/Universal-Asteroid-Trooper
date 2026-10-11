using UnityEngine;

public class GameplayAudioListener : MonoBehaviour
{
    public PlayerController playerController;

    void LateUpdate()
    {
        if (playerController != null && playerController.pawn != null)
        {
            transform.position = playerController.pawn.transform.position;
        }
    }
}
