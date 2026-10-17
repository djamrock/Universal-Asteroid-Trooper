using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.instance.obstacleList.Add(this); // register this obstacle component to the list of obstacles
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
