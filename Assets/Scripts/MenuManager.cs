using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
	public static void NextScene(string scene)
    {
        SceneManager.LoadScene(scene, LoadSceneMode.Single);

        // Generation screws up at the beginning and can be actually impossible if I don't include this
        PlayerMovement.pathLastXValue = 0;
    }
}
