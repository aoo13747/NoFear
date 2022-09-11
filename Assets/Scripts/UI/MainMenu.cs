using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MainMenu : MonoBehaviour
{
    public SceneFader sceneFader;
    public string sceneToLoad;
    public void StartGame()
    {
        sceneFader.FadeTo(sceneToLoad);
    }    
    public void ExitGame()
    {
        Application.Quit();
    }
}
