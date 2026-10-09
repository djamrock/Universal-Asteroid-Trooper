using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public PlayerController playerController;

    public List<Obstacle> obstacleList;

    public int score;

    public TMP_Text text;

    public AudioClip victorySound;

    public AudioClip failureSound;

    public float victoryVolume = 1f;

    public AudioSource audioSource;

    public bool gameEnded = false;

    public GameObject TitleScreenStateObject;

    public GameObject MainMenuScreenStateObject;

    public GameObject OptionsScreenStateObject;

    public GameObject CreditsScreenStateObject;

    public GameObject GameplayStateObject;

    public GameObject GameOverScreenStateObject;

    public int lives = 3;

    public GameObject playerPawnPrefab;

    public GameObject[] lifeIcons;  // variable set as an array to have multiple values (the life icons in the top right), the [] makes it an array

    public AsteroidSpawner asteroidSpawner;

    public float respawnDelay = 1.5f;



    public void Awake()
    {
        obstacleList = new List<Obstacle>(); // initalizes the data stucture that is capable of storing the collection of obstacles in memory

        audioSource = GetComponent<AudioSource>();

        if (instance == null) // if there is not already a game manager, create DontDestroyOnLoad
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else //if there already is a game manager, destroy this instance of it
        {
            Destroy(gameObject);
        }
    } 


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ActivateTitleScreen();
    }

    // Update is called once per frame
    void Update()
    {
        if (obstacleList != null)
        {
            if (obstacleList.Count <= 0 && playerController != null)
            {
                if (playerController.pawn != null)
                {
                    Debug.Log("Victory!");

                    if (gameEnded == false)     // only run if the game hasnt ended
                    {
                        gameEnded = true;       // prevent victory code from running again

                        if (victorySound != null && audioSource != null)    // check to see if both are assigned
                        {
                            AudioSource.PlayClipAtPoint(victorySound, transform.position, victoryVolume);     // play victory sound once
                        }
                    }
                    Time.timeScale = 0f;    // Game Time is paused so no more asteroids spawn and Victory happens
                }
            }
        }

        //if (playerController != null)
        //{
        //    if (playerController.pawn == null)
        //    {
        //        Debug.Log("Failure!");
        //        Time.timeScale = 0f;     // Game Time is paused so no more asteroids spawn and Failure happens

        //    }
        //}

        if (text != null)
        {
            text.text = "" + score;
        }
    }

    public void PlayFailureSound()
    {
        if (failureSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(failureSound);
        }
    }


    // Deactivate every game state as default
    private void DeactivateAllStates()
    {
        TitleScreenStateObject.SetActive(false);
        MainMenuScreenStateObject.SetActive(false);
        OptionsScreenStateObject.SetActive(false);
        CreditsScreenStateObject.SetActive(false);
        GameplayStateObject.SetActive(false);
        GameOverScreenStateObject.SetActive(false);
    }

    public void ActivateTitleScreen()
    {
        // Deactivate all states
        DeactivateAllStates();

        // Activate the title screen
        TitleScreenStateObject.SetActive(true);
    }

    public void ActivateGameplayScreen()
    {
        // Deactivate all states
        DeactivateAllStates();

        Time.timeScale = 1f;
        gameEnded = false;
        lives = 3;

        UpdateLivesUI();

        // Activate the Gameplay screen
        GameplayStateObject.SetActive(true);
    }

    public void ActivateMainMenuScreen()
    {
        // Deactivate all states
        DeactivateAllStates();

        // Activate the Main Menu screen
        MainMenuScreenStateObject.SetActive(true);
    }

    public void ActivateOptionsScreen()
    {
        // Deactivate all states
        DeactivateAllStates();

        // Activate the Options screen
        OptionsScreenStateObject.SetActive(true);
    }

    public void ActivateCreditsScreen()
    {
        // Deactivate all states
        DeactivateAllStates();

        // Activate the Credits screen
        CreditsScreenStateObject.SetActive(true);
    }

    public void ActivateGameOverScreen()
    {
        // Deactivate all states
        DeactivateAllStates();

        // Activate the Game Over screen
        GameOverScreenStateObject.SetActive(true);
    }

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
        if (gameEnded)
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

        if (lives <=0)
        {
            gameEnded = true;
            ActivateGameOverScreen();
            Time.timeScale = 0f;
        }
        else
        {
            Invoke(nameof(RespawnPlayer), respawnDelay);
        }
     }

    public void RespawnPlayer()
    {
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
