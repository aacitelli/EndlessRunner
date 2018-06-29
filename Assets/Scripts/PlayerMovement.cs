using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Public Variables
    public static float pathLastXValue;    // This value needs to be the same across every path segment, and this is the only class that is the same across all of them
    public static float xCoord; // Used by the path class to check for collision - Doing it the non-Unity way because unity doesn't really have what I want
    public static bool pathHasMovedThisFrame = false;

    // Private Variables
    private int count = 0;
    
    // Run once at the start of the game
    private void Start()
    {
        // Makes quite a few extras to account for higher speeds
        // Todo - Make this make different amounts for each of the difficulties. Don't forget that it gets faster as time goes on, or at least is supposed to
        for (float y = 4; y < 16; y += .1f)
        {
            PathBehavior.CreateInitialObjects(y - 10);
        }
    }

    // Update is called once per frame
    void Update()
    {
        pathHasMovedThisFrame = false;
        updateLocation(); // Used for collision by the path classes

        // If they have the "left" key pressed
        if (Input.GetKey(KeyCode.LeftArrow) && this.transform.position.x > -12.8f)
        {
            Vector3 position = this.transform.position;
            position.x -= .2f;
            this.transform.position = position;
        }

        // If they have the "right" key pressed
        if (Input.GetKey(KeyCode.RightArrow) && this.transform.position.x < 12.8f)
        {
            Vector3 position = this.transform.position;
            position.x += .2f;
            this.transform.position = position;
        }
        
        // If I get in any infinite loops by accident, this will hopefully work
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
	}

    // Used for collision
    void updateLocation()
    {
        xCoord = this.transform.position.x;
    }
}
