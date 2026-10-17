using System.Collections.Generic;
using UnityEngine;



public class LevelData : MonoBehaviour
{
    public string levelName = "Test Level";

    public Vector3 levelSize = new Vector3(100f, 100f, 100f);


    // Player Movement Limit
    public float maxYPosition = 20f;
    public Transform player;

    // Spawn Points
    public List<SpawnPoint> spawnPoints = new List<SpawnPoint>();


    private void Awake()
    {
        SpawnPoint[] foundSpawnPoints = GetComponentsInChildren<SpawnPoint>();

        spawnPoints = new List<SpawnPoint>(foundSpawnPoints);

        Debug.Log("Found " + spawnPoints.Count + " spawn points.");
    }



    void LateUpdate()
    {
        if (player == null)
        {
            return;
        }

        if (player.position.y > maxYPosition)
        {
            Vector3 newPosition = player.position;
            newPosition.y = maxYPosition;

            player.position = newPosition;

            Rigidbody playerRb = player.GetComponent<Rigidbody>();

            if (playerRb != null && playerRb.linearVelocity.y > 0f)
            {
                Vector3 velocity = playerRb.linearVelocity; velocity.y = 0f; playerRb.linearVelocity = velocity;
            }
        }

    }



}

