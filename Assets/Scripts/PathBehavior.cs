using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PathBehavior : MonoBehaviour
{
    const float EASY_DIFFICULTY = .06f, MEDIUM_DIFFICULTY = .08f, HARD_DIFFICULTY = .1f, TESTING_DIFFICULTY = .4f;
    private static Vector3 newPos;
    Vector3 wrld; 
    float halfWidth;


    // Initialization of VariablesS
    private void Start()
    {
        wrld = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0.0f, 0.0f));
        halfWidth = GetComponent<SpriteRenderer>().bounds.size.x / 2;
        
    }

    // Called once per frame
    private void Update()
    {
        ReuseObject();

        if (SceneManager.GetActiveScene().name.Equals("MainSceneFinal"))
        {
            CheckCollision();
        }

        // Moves downward slowly - This works fine
        Vector3 position = this.transform.position;
        position.y = this.transform.position.y - HARD_DIFFICULTY - .25f;
        this.transform.position = position;        
    }

    // Used only to make all the stuff at the beginning
    public static void CreateInitialObjects(float yPos)
    {
        // Actually making the new object
        newPos = new Vector3(0, yPos, 90);        
        Instantiate((GameObject)Resources.Load("PathSprite"), newPos, Quaternion.identity);               
    }
    
    // Whenever
    private void ReuseObject()
    {
       // Resets it back to the top of the screen - Only does it if no path has already moved back up top
       if (transform.position.y <= -6)
       {
            Vector3 position = this.transform.position;
            position.y = 6f;
            position.x = PlayerMovement.pathLastXValue + Random.Range(-wrld.x * .01f, wrld.x * .01f);

            // These two lines are to make sure the path never generates off of the screen. Works by resetting the value to closer inside the screen, but offset by a small random value so it doesn't just show up as a straight line
            if (position.x >= wrld.x - halfWidth)
                position.x = wrld.x - halfWidth + Random.Range(-.5f, .5f);
            else if (position.x <= (-1 * wrld.x) + halfWidth)
                position.x = (-1 * wrld.x) + halfWidth + Random.Range(-.5f, .5f);

            // If everything checks out, the position of the sprite is set
            this.transform.position = position;

            PlayerMovement.pathLastXValue = position.x;
        }
    }

    // Collision isn't pixel perfect (which is ultimately the end goal, and requres a different collision system), but it's like 99% accurate and that's good enough for now
    private void CheckCollision()
    {
        // Checking that it's in the right y-coordinate
        if (this.transform.position.y <= -2.2f && this.transform.position.y >= -3.8f)
        {
            if (Mathf.Abs(transform.position.x - PlayerMovement.xPos) > 3.4f)
            {
                Application.Quit();
            }
        }
    }
}
