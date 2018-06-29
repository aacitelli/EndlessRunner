using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathBehavior : MonoBehaviour
{
    const float EASY_DIFFICULTY = .06f, MEDIUM_DIFFICULTY = .08f, HARD_DIFFICULTY = .1f, TESTING_DIFFICULTY = .4f;

    // Initialization of Variables
    private void Start()
    {
        PlayerMovement.pathLastXValue = 0;
    }

    // Called once per frame
    private void Update()
    {        
        // Moves downward slowly - This works fine
        Vector3 position = this.transform.position;

        // Todo - Implement time elapsed into this
        position.y = this.transform.position.y - HARD_DIFFICULTY;
        this.transform.position = position;        
    }
    
    // Called in time intervals, not per frame - Use this for physics stuff so it looks consistent regardless of lag
    private void FixedUpdate()
    {
        // Checks if they go off the bottom of the screen and sends them back up top
        ReuseObject();
        CheckCollision();
    }

    // Makes a 
    public static void CreateInitialObjects(float yPos)
    {
        Vector3 newPos;
        
        // Actually making the new object
        newPos = new Vector3(0, yPos, 90);        
        Instantiate((GameObject)Resources.Load("PathSprite"), newPos, Quaternion.identity);               
    }
    
    // Checks if it is below the camera, and if so, puts it back up top with a new x-coordinate that makes sense so the whole thing isn't straight
    private void ReuseObject()
    {
       // Resets it back to the top of the screen - Only does it if no path has already moved back up top
       if (transform.position.y < -6 && !PlayerMovement.pathHasMovedThisFrame)
       {
            PlayerMovement.pathHasMovedThisFrame = true;

            Vector3 position = this.transform.position;
            position.y = 6f;
            position.x = PlayerMovement.pathLastXValue + Random.Range(-.4f, .4f);

            // These two lines are to make sure the path never generates off of the screen. Works by resetting the value to closer inside the screen, but offset by a small random value so it doesn't just show up as a straight line
            if (position.x >= 10)
                position.x = 10 + Random.Range(-.1f, .1f);
            else if (position.x <= -10)
                position.y = -10 + Random.Range(-.1f, .1f);

            // If everything checks out, the position of the sprite is set
            this.transform.position = position;

            PlayerMovement.pathLastXValue = position.x;
        }
    }

    private void CheckCollision()
    {
        // Checking Y-coordinate first because that will rule out more than once and be slightly more efficient
        if (this.transform.position.y <= -2.4 && this.transform.position.y >= 3.6)
        {
            // Checking that the player is close enough to the middle of all the platforms at the current y-coordinate
            if (!(Mathf.Abs(this.transform.position.x - PlayerMovement.xCoord) <= 3.5f))
            {
                Application.Quit(); // Todo - Make this take you back to a menu or something
            }
        }
    }
}
