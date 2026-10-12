using UnityEngine;

public class GameplayAudioListener : MonoBehaviour
{
    public PlayerController playerController;

    void LateUpdate()                                                           // Uses LateUpdate - changes happen after Update and FixedUpdate (used for physics). Makes sure camera can get pawns location even after respawning
    {
        if (playerController != null && playerController.pawn != null)
        {
            transform.position = playerController.pawn.transform.position;
        }
    }
}
