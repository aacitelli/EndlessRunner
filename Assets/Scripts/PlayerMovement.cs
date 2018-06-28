using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // This value needs to be the same across every path segment, and this is the only class that is the same across all of them
    public static float pathLastXValue;

    private void Start()
    {
        for (float y = 4; y < 16; y += .125f)
        {
            PathBehavior.CreateInitialObjects(y - 10);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // If they have the "left" key pressed
        if (Input.GetKey(KeyCode.LeftArrow) && this.transform.position.x > -9.8f)
        {
            Vector3 position = this.transform.position;
            position.x -= .2f;
            this.transform.position = position;
        }

        // If they have the "right" key pressed
        if (Input.GetKey(KeyCode.RightArrow) && this.transform.position.x < 9.8f)
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
}
