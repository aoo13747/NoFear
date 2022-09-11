using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelect : MonoBehaviour
{
    public SceneFader sceneFader;
    public string sceneToLoad;
    public void LoadGameDay()
    {
        sceneToLoad = "GameplayNormal";
        sceneFader.FadeTo(sceneToLoad);
    }
    public void LoadGameNight()
    {
        sceneToLoad = "GameplayNight";
        sceneFader.FadeTo(sceneToLoad);
    }
    public void ReturnMainmenu()
    {
        sceneToLoad = "MainMenu";
        sceneFader.FadeTo(sceneToLoad);
    }
}
