using UnityEngine;




public class ShipDeath : MonoBehaviour
{


    public void Die()
    {
        Debug.Log("The ship has been destroyed!");

        gameObject.SetActive(false);        // Inactivates the ship or object when it dies
    }



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
