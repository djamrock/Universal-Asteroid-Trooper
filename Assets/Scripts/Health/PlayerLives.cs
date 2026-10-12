using UnityEngine;

public class PlayerLives : MonoBehaviour
{

    public GameObject[] lifeIcons;  // variable set as an array to have multiple values (the life icons in the top right), the [] makes it an array

    public int lives = 3;

    public GameObject playerPawnPrefab;

    public AsteroidSpawner asteroidSpawner;

    public float respawnDelay = 1.5f;

    public GameObject gameplayAudioListener;

    public AudioListener cameraAudioListener;

    public PlayerController playerController;

    public GameObject GameOverScreenStateObject;


    public void UpdateLivesUI()         // Updates the life icons in the top right of the gameplay UI
    {
        if (lifeIcons == null)          
        {
            return;
        }

        for (int i = 0; i < lifeIcons.Length; i += 1)       // Loops through each life icon, activates the icon if the position in the array is less than the number of lives remaining
        {                                                   // and hides the icon if the life has been lost
            if (lifeIcons[i] != null)                       // Life 1, 2 and 3 are assigned in the Inspector, number of lives are editable in Inpsector, just have to add more Icons if more lives are added
            {
                lifeIcons[i].SetActive(i < lives);
            }
        }
    }
    public void HandlePlayerDeath()                     // Runs when the player pawn is destroyed, removes a life and decides whether the player should respawn or the game should end
    {
        if (GameManager.instance.gameEnded)
        {
            return;
        }

        lives = Mathf.Max(0, lives - 1);            // Decreases lives by 1. Math.Max compares 1st # to 2nd # , returns larger (prevents lives going negative)

        UpdateLivesUI();                            // Calls above to update UI

        if (playerController != null)               // Clears the controller while pawn is dead waiting respawn so no errors occur
        {
            playerController.pawn = null;
        }

        if (asteroidSpawner != null)                // Clears the ships position after its destroyed while waiting to respawn so spawning asteroids arent using the old location
        {
            asteroidSpawner.starShipPawn = null;
        }

        if (lives <= 0)                                         // If player has no lives left, game over happens
        {
            GameManager.instance.gameEnded = true;
            GameManager.instance.ActivateGameOverScreen();      // Activates Game Over Screen
            Time.timeScale = 0f;                                // Pauses game time, essentially everything gameplay wise stops
        }
       
        else                                                                       // If lives still exist, player respawns. Delay is editable in Inspector
        {
            Invoke(nameof(RespawnPlayer), respawnDelay);
        }
    }

    public void RespawnPlayer()
    {
        if (playerPawnPrefab == null)                           // These check to make sure a prefeb and controller is assigned for spawning
        {
            return;
        }

        if (playerController == null)
        {
            return;
        }

        Camera mainCamera = Camera.main;                        // Here down finds the main camera, calculates the center of the screen, converts it into a position in the world,
                                                                // creates a new ship at that position, assigns a new controller, and tells the asteroid spawner the new location
        if (mainCamera == null)
        {
            return;
        }

        Vector3 screenCenter = new Vector3(Screen.width / 2f, Screen.height / 2f, -mainCamera.transform.position.z); // Gets center of the screen (width and height each divided by 2 to find center), negative camera for 2D games

        Vector3 spawnPosition = mainCamera.ScreenToWorldPoint(screenCenter);        // Converts above to game world position

        spawnPosition.z = 0f;                                                       // Sets new ship to zero on the Z plane

        GameObject newShip = Instantiate(playerPawnPrefab, spawnPosition, Quaternion.identity);     // Creates the new ship, puts it at location determined above using the assigned prefab, with no rotation

        Pawn newPawn = newShip.GetComponent<Pawn>();                    

        if (newPawn == null)                                // Checks to see if GetComponent<Pawn> succeeded, destroys new ship if it was incorrect, prevents a random unusable ship from being in the game
        {
            Destroy(newShip);
            return;
        }

        playerController.pawn = newPawn;                    // Assigns controller to new pawn

        if (asteroidSpawner != null)                                // Gives the new location to asteroid spawner
        {
            asteroidSpawner.starShipPawn = newShip.transform;
        }

    }

}
