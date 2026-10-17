using UnityEngine;

public class SpriteChanger : MonoBehaviour

{
    // Declare our variables
    private SpriteRenderer theRenderer; // variable for our renderer

    public Color spriteColor; // variable for our color

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Load the SpriteRenderer component from the same object this component is on
        theRenderer = gameObject.GetComponent<SpriteRenderer>();
        
        // Change the color to a random color
        spriteColor.a = 1.0f; // Change the color from our color picker so that the alpha is 1
        spriteColor.r = Random.Range(0.0f, 1.0f); // This makes the variable have a random red value, somewhere between 0 and 1.
        spriteColor.g = 1.0f; // This makes the variable have a red value of 0% green.
        spriteColor.b = Random.Range(0.0f, 1.0f); // This makes the variable have a random green value, somewhere between 0 and 1.

        // As long as theRenderer has been set
        if (theRenderer != null)
        {
            // Change the "color" value of the SpriteRenderer component to our new color
            theRenderer.color = spriteColor;
        }

       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
