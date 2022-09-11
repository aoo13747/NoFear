using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseUi;
    public SceneFader sceneFader;
    public string menuSceneName = "";

    [HideInInspector]
    public static bool isPause = false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            Toggle();
        }
    }

    void Toggle()
    {
        pauseUi.SetActive(!pauseUi.activeSelf);
        if (pauseUi.activeSelf)
        {
            Time.timeScale = 0;
            isPause = true;
        }
        else
        {
            Time.timeScale = 1;
            isPause = false;
        }
    }

    public void Continue()
    {
        Toggle();
    }
    public void MainMenu()
    {
        sceneFader.FadeTo(menuSceneName);
        Toggle();
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
