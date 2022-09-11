using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MainMenu : MonoBehaviour
{
    public SceneFader sceneFader;
    public string sceneToLoad;
    public void StartGame()
    {
        sceneToLoad = "StageSelect";
        sceneFader.FadeTo(sceneToLoad);
    }    
    public void MainMenuScene()
    {
        sceneToLoad = "MainMenu";
        sceneFader.FadeTo(sceneToLoad);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
