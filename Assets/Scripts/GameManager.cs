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

    public int lives = 3;

    public GameObject playerPawnPrefab;

    public AsteroidSpawner asteroidSpawner;

    public float respawnDelay = 1.5f;

    public GameObject gameplayAudioListener;

    public AudioListener cameraAudioListener;

    public GameObject GameOverScreenStateObject;

    public bool startingNewGame = false;

    public GameObject TitleScreenStateObject;

    public GameObject MainMenuScreenStateObject;

    public GameObject OptionsScreenStateObject;

    public GameObject CreditsScreenStateObject;

    public GameObject GameplayStateObject;

    public GameObject VictoryScreenStateObject;

    public PlayerLives playerLives;



    public void Awake()
    {
        if (Camera.main != null)
        {
            cameraAudioListener = Camera.main.GetComponent<AudioListener>();
        }

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
        if (startingNewGame)
        {
            if (obstacleList != null && obstacleList.Count > 0)
            {
                startingNewGame = false;
            }

            else
            {
                return;
            }
        }

        if (obstacleList != null)
        {
            if (gameEnded == false && obstacleList.Count <= 0 && playerController != null)      // if player controller is still assigned (meaning player is alive), obstacle list is zero, and the game hasnt ended
            {
                if (playerController.pawn != null)
                {
                    Debug.Log("Victory!");
                    ActivateVictoryScreen();

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
        VictoryScreenStateObject.SetActive(false);
    }

    public void ActivateTitleScreen()
    {
        // Deactivate all states
        DeactivateAllStates();

        if (gameplayAudioListener != null)
        {
            gameplayAudioListener.SetActive(false);
        }

        if (cameraAudioListener != null)
        {
            cameraAudioListener.enabled = true;
        }

        // Activate the title screen
        TitleScreenStateObject.SetActive(true);
    }

    public void ActivateGameplayScreen()
    {
        // Deactivate all states
        DeactivateAllStates();

        if (cameraAudioListener != null)
        {
            cameraAudioListener.enabled = false;
        }

        if(gameplayAudioListener != null)
        {
            gameplayAudioListener.SetActive(true);
        }

        Time.timeScale = 1f;
        gameEnded = false;
        startingNewGame = true;
        score = 0;

        if (playerLives != null)
        {
            playerLives.lives = 3;
            playerLives.UpdateLivesUI();
        }

        // Activate the Gameplay screen
        GameplayStateObject.SetActive(true);
    }

    public void ActivateMainMenuScreen()
    {
        // Deactivate all states
        DeactivateAllStates();

        if (gameplayAudioListener != null)
        {
            gameplayAudioListener.SetActive(false);
        }

        if (cameraAudioListener != null)
        {
            cameraAudioListener.enabled = true;
        }

        // Activate the Main Menu screen
        MainMenuScreenStateObject.SetActive(true);
    }

    public void ActivateOptionsScreen()
    {
        // Deactivate all states
        DeactivateAllStates();

        if (gameplayAudioListener != null)
        {
            gameplayAudioListener.SetActive(false);
        }

        if (cameraAudioListener != null)
        {
            cameraAudioListener.enabled = true;
        }

        // Activate the Options screen
        OptionsScreenStateObject.SetActive(true);
    }

    public void ActivateCreditsScreen()
    {
        // Deactivate all states
        DeactivateAllStates();

        if (gameplayAudioListener != null)
        {
            gameplayAudioListener.SetActive(false);
        }

        if (cameraAudioListener != null)
        {
            cameraAudioListener.enabled = true;
        }

        // Activate the Credits screen
        CreditsScreenStateObject.SetActive(true);
    }

    public void ActivateGameOverScreen()
    {
        // Deactivate all states
        DeactivateAllStates();

        if (gameplayAudioListener != null)
        {
            gameplayAudioListener.SetActive(false);
        }

        if (cameraAudioListener != null)
        {
            cameraAudioListener.enabled = true;
        }

        // Activate the Game Over screen
        GameOverScreenStateObject.SetActive(true);
    }

    public void ActivateVictoryScreen()
    {
        // Deactivate all states
        DeactivateAllStates();

        if (gameplayAudioListener != null)
        {
            gameplayAudioListener.SetActive(false);
        }

        if (cameraAudioListener != null)
        {
            cameraAudioListener.enabled = true;
        }

        // Activate the Victory screen
        VictoryScreenStateObject.SetActive(true);
    }



}
