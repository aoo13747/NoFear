using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;    
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }    
    public void PlayerDied()
    {
        StartCoroutine(RestartGame());
    }
    IEnumerator RestartGame()
    {
        Time.timeScale = .3f;

        yield return new WaitForSecondsRealtime(3f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
