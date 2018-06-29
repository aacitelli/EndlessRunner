using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    private void NextScene(string scene)
    {
        SceneManager.LoadScene("MainSceneFinal");
    }
}
