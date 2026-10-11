using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{

    public GameObject asteroidPrefab;   // lets me add the Asteroid prefab to the inspector so it can be spawned

    public GameObject ufoPreFab;

    public GameObject largeAsteroidPrefab;

    public Camera mainCamera;           // store reference to the camera being used to determine where on the screen the asteroid can spawn

    public Transform starShipPawn;      // lets me add the StarShipPawn in Inspector so asteroids cant spawn on it or too close

    public float minimumSpawnDistance = 2f;     // creates a number that controls how close an asteroid is allowed to spawn to the player or other asteroids, defaulted to 2 units

    public float spawnInterval = 5f;            // how often Asteroids will spawn, defaulted to 5 seconds

    [Range(0f, 1f)]                         // sets a slider from 0-1 in Inspector instead of a reg number
    public float ufoSpawnChance = 0.15f;

    [Range(0f, 1f)]                         // sets a slider from 0-1 in Inspector instead of a reg number
    public float largeAsteroidSpawnChance = 0.15f;


    public void Start()
    {
        
    }


    void OnEnable()
    {
        if (mainCamera == null)                         // Checks to see if mainCamera has no camera assigned, adds Main Camera to mainCamera if so
        {
            mainCamera = Camera.main;
        }
        InvokeRepeating("SpawnAsteroid", 0f, spawnInterval);  // InvokeRepeating repeatedly runs SpawnAsteroid, and needs a method, delay, and repeatRate input into it. It gets SpawnAsteroid, runs immediately because of 0f(no delay so it adds an Asteroid as soon as the game starts), then pulls the SpawnInterval which is set to 5 seconds, the the next asteroid comes onscreen 5 seconds later, every 5 seconds)
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

   
    void Update()
    {

    }


    void SpawnAsteroid()
    {
        if (starShipPawn == null || (asteroidPrefab == null && ufoPreFab == null && largeAsteroidPrefab == null))  // enemy spawns stop if player dies, or asteroids and ufos are all gone
        {
            return;
        }

        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }

        if (mainCamera == null)
        {
            return;
        }

        Vector3 worldPosition;      // creating a variable for the asteroids world position

        do                          // starts a do / while loop. It runs the random position generator, then the While part checks it against the minimum spawn distance. If its good, it stops. If its too close, it runs again. 

        {
            float bottomUIHeight = 300f;

            float sideMargin = 50f;

            Vector3 screenPosition = new Vector3(               // creating screenPosition, represents a location on the game screen. Then picks a random number at least 50 pixels from the left and right
               Random.Range(sideMargin, Screen.width - sideMargin),           // and 100 pixels from the top and bottom to not appear under any UI elements
               Random.Range(bottomUIHeight, Screen.height - 0.15f),        // the 0f at the end is just for the Z plane, not used in the 2D
               0f
           );

            worldPosition = mainCamera.ScreenToWorldPoint(screenPosition);      // converts screen position to world position. Random position was in pixels, Unity uses world position
            worldPosition.z = 0f;                                               // set Z to 0, not used in 2D

        } while (
            Vector2.Distance(worldPosition, starShipPawn.position) < minimumSpawnDistance || TooCloseToAsteroid(worldPosition));    // gets the location of the StarShipPawn. Vector2.Distance is calculating the distance between the 2 input points (worldPosition and starShipPawn position) and seeing if its less than the minimumSpawnDistance. If so, it runs again and picks a new location. Then its looking to see if its also too close to an asteroid. 

        GameObject prefabToSpawn = asteroidPrefab;

        float spawnChance = Random.value;

        if (ufoPreFab != null && spawnChance < ufoSpawnChance)
        {
            prefabToSpawn = ufoPreFab;
        }
        else if (largeAsteroidPrefab != null && spawnChance < ufoSpawnChance + largeAsteroidSpawnChance)
        {
            prefabToSpawn = largeAsteroidPrefab;
        }

        if (prefabToSpawn != null)
        {
            Instantiate(prefabToSpawn, worldPosition, Quaternion.identity);    // creates the asteroid prefab at the random world position determined above with no rotation
        }
    }


    bool TooCloseToAsteroid(Vector3 position)
    {
        if (GameManager.instance == null ||
            GameManager.instance.obstacleList == null)
        {
            return false;
        }

        // Check the asteroid list backwards so destroyed entries
        // can be safely removed.
        for (int i = GameManager.instance.obstacleList.Count - 1; i >= 0; i--)
        {
            Obstacle obstacle = GameManager.instance.obstacleList[i];    // this goes through each instance of asteroid in the game manager obstacle list

            // Remove references to asteroids that no longer exist.
            if (obstacle == null)
            {
                GameManager.instance.obstacleList.RemoveAt(i);
                continue;
            }

            // Check the distance to existing asteroids.
            if (Vector2.Distance(position, obstacle.transform.position) < minimumSpawnDistance) // check how far the potential spawn location is, and checks it against the minimum spawn distance
            {
                return true;    // this position is too close to another asteroid, it makes the TooCloseToAsteroid portion of the While loop fail and have to run a
            }
        }

        return false;           // this position isnt too close to another asteroid, it lets the TooCloseToAsteroid portion of the While loop pass
    }

}
