using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public string puzzleName;
    public string titleSceneName = "Main Title";
    public string instructionsScene;

    public void LoadLevel()
    {
        SceneManager.LoadScene(puzzleName);
    }
    
    public void LoadTitleScreen()
    {
        SceneManager.LoadScene(titleSceneName);
    }

    public void LoadInstructionScene()
    {
        SceneManager.LoadScene(instructionsScene);
    }
}

 