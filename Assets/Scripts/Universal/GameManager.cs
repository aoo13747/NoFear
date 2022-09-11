using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject enemySpawner;
    public GameObject diedUI;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        enemySpawner.SetActive(false);
        diedUI.SetActive(false);
        StartCoroutine(OnGameStart());
    }   
    IEnumerator OnGameStart()
    {
        yield return new WaitForSeconds(2f);
        enemySpawner.SetActive(true);
        Time.timeScale = 1;
    }
    public void PlayerDied()
    {
        diedUI.SetActive(true);
        StartCoroutine(RestartGame());
    }
    IEnumerator RestartGame()
    {
        Time.timeScale = .5f;
        yield return new WaitForSecondsRealtime(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
