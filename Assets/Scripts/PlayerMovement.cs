using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{
    // Public Variables
    public static float pathLastXValue = 0;    // This value needs to be the same across every path segment, so it's in this class, which is global
    public static float xPos = 0;
    private static int count = 0;

    Vector3 wrld;
    float halfSize;

    // Run once at the start of the game
    private void Start()
    {
        halfSize = GetComponent<SpriteRenderer>().bounds.size.x / 2;

        wrld = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0.0f, 0.0f));
       
        
        // Makes quite a few extras to account for higher speeds
        for (float y = 4; y < 16; y += .025f)
        {
            PathBehavior.CreateInitialObjects(y - 10);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Used for collision
        xPos = transform.position.x;

        // Move Left - Checks for edge of screen
        if (Input.GetKey(KeyCode.LeftArrow) && this.transform.position.x > (-1 * wrld.x) + halfSize)
        {
            Vector3 position = this.transform.position;
            position.x -= wrld.x * .015f;
            this.transform.position = position;
        }

        // Move right - Checks for edge of screen
        if (Input.GetKey(KeyCode.RightArrow) && this.transform.position.x < wrld.x - halfSize)
        {
            Vector3 position = this.transform.position;
            position.x += wrld.x * .015f;
            this.transform.position = position;
        }
	}

    public static void RegisterHit()
    {
        count++;
        print(count);
    }

    
}
