/* Todo - 
 *      I think my current implementation means that the last x-coord is saved specific to each section of the path. 
 *          - Will have to figure out how to fix that.
 *      */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathBehavior : MonoBehaviour
{
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
        position.y = this.transform.position.y - .25f;
        this.transform.position = position;        
    }
    
    // Called in time intervals, not per frame - Use this for physics stuff so it looks consistent regardless of lag
    private void FixedUpdate()
    {
        ReuseObject();
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
       // Resets it back to the top of the screen
       if (transform.position.y < -6)
        {
            Vector3 position = this.transform.position;
            position.y = 6f;
            position.x = PlayerMovement.pathLastXValue + Random.Range(-.4f, .4f);
            this.transform.position = position;

            PlayerMovement.pathLastXValue = position.x;
        }
    }
}
