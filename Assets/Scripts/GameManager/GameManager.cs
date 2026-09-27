using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public PlayerController playerController;

    public List<Obstacle> obstacleList;


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