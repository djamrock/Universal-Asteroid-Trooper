using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public PlayerController playerController;

    public List<Obstacle> obstacleList;

    public GameObject TitleScreenStateObject;

    public GameObject MainMenuStateObject;

    public GameObject OptionsScreenStateObject;

    public GameObject CreditsScreenStateObject;

    public GameObject GameplayStateObject;

    public GameObject GameOverScreenStateObject;



    private void DeactivateAllStates()
    {
        TitleScreenStateObject.SetActive(false);
        MainMenuStateObject.SetActive(false);
        OptionsScreenStateObject.SetActive(false);
        CreditsScreenStateObject.SetActive(false);
        GameplayStateObject.SetActive(false);
        GameOverScreenStateObject.SetActive(false);
    }

    public void ActivateTitleScreen()
    {
        DeactivateAllStates();
        TitleScreenStateObject.SetActive(true);
    }

    public void ActivateMainMenu()
    {
        DeactivateAllStates();
        MainMenuStateObject.SetActive(true);
    }

    public void ActivateOptionsScreen()
    {
        DeactivateAllStates();
        OptionsScreenStateObject.SetActive(true);
    }
    public void ActivateCreditsScreen()
    {
        DeactivateAllStates();
        CreditsScreenStateObject.SetActive(true);
    }
    public void ActivateGameplay()
    { 
        DeactivateAllStates();
        GameplayStateObject.SetActive(true);
    }
    public void ActivateGameOverScreen()
    {
        DeactivateAllStates();
        GameOverScreenStateObject.SetActive(true);
    }

    public void Awake()
    {
        obstacleList = new List<Obstacle>(); // initalizes the data stucture that is capable of storing the collection of obstacles in memory

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
                }
            }
        }
        if (playerController != null)
        {
            if (playerController.pawn == null)
            {
                Debug.Log("Failure!");
            }
        }
    }
}