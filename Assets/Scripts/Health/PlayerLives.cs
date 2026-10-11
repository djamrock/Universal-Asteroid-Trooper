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


    public void UpdateLivesUI()
    {
        if (lifeIcons == null)
        {
            return;
        }

        for (int i = 0; i < lifeIcons.Length; i += 1)
        {
            if (lifeIcons[i] != null)
            {
                lifeIcons[i].SetActive(i < lives);
            }
        }
    }
    public void HandlePlayerDeath()
    {
        Debug.Log("HandlePlayerDeath was called");
        if (GameManager.instance.gameEnded)
        {
            return;
        }

        lives = Mathf.Max(0, lives - 1);

        UpdateLivesUI();

        if (playerController != null)
        {
            playerController.pawn = null;
        }

        if (asteroidSpawner != null)
        {
            asteroidSpawner.starShipPawn = null;
        }

        if (lives <= 0)
        {
            GameManager.instance.gameEnded = true;
            GameManager.instance.ActivateGameOverScreen();
            Time.timeScale = 0f;
        }
        else
        {
            Debug.Log("Scheduling respawn in " + respawnDelay + " seconds.");
            Invoke(nameof(RespawnPlayer), respawnDelay);
        }
    }

    public void RespawnPlayer()
    {
        Debug.Log("RespawnPlayer was called");
        if (playerPawnPrefab == null)
        {
            Debug.LogError("Player Pawn Prefab is not assigned!");
            return;
        }

        if (playerController == null)
        {
            Debug.LogError("Player controller is not assigned!");
            return;
        }

        Camera mainCamera = Camera.main;

        if (mainCamera == null)
        {
            Debug.LogError("Main Camera was not found!");
            return;
        }

        Vector3 screenCenter = new Vector3(
            Screen.width / 2f,
            Screen.height / 2f,
            -mainCamera.transform.position.z);

        Vector3 spawnPosition =
            mainCamera.ScreenToWorldPoint(screenCenter);

        spawnPosition.z = 0f;

        GameObject newShip = Instantiate(
            playerPawnPrefab,
            spawnPosition,
            Quaternion.identity);

        Pawn newPawn = newShip.GetComponent<Pawn>();

        if (newPawn == null)
        {
            Debug.LogError("Player Pawn Prefab must have a Pawn component!");

            Destroy(newShip);
            return;
        }

        playerController.pawn = newPawn;

        if (asteroidSpawner != null)
        {
            asteroidSpawner.starShipPawn = newShip.transform;
        }

    }

}
