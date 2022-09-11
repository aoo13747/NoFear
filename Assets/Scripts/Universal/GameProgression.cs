using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameProgression : MonoBehaviour
{
    public static int waveScore;

    public static GameProgression instance;

    public Levels[] levels;

    public PlayerShooter playerShooter;
    public PlayerStats player;
    public EnemySpawner enemySpawner;    

    //public Slider waveSlider;

    public GameObject upgradeUI;
    public GameObject waveClearUI;

    public TextMeshProUGUI waveText;
    public static int currentWave;
    public int wave;
    public SceneFader sceneFader;
    public string sceneToLoad;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        waveScore = 0;

        //waveSlider.value = 0;

        Time.timeScale = 1f;
    }
    private void Start()
    {
        wave = 1;
        enemySpawner.currentWave = levels[0].wave;
        levels[0].isUnlock = true;
        waveText.text = wave.ToString();
        //waveSlider.maxValue = levels[1].scoreToUnlock;
    }        
    public void AddScore(int amount)
    {
        waveScore += amount;        
        //waveSlider.value = waveScore;
        for (int i = 0; i < levels.Length; i++)
        {
            if (!levels[i].isUnlock && waveScore >= levels[i].scoreToUnlock)
            {
                if (levels[i].endGame)
                {
                    StartCoroutine(EndGame());
                }
                else
                {
                    UpLevel();
                    wave += 1;
                    waveText.text = wave.ToString();
                }                
                StartCoroutine(NextWave());
                enemySpawner.currentWave = levels[i].wave;
                //if (i < levels.Length - 1)
                //{
                //    waveSlider.minValue = waveScore;
                //    waveSlider.maxValue = levels[i + 1].scoreToUnlock;
                //}
                levels[i].isUnlock = true;                
            }
        }
    }
    void UpLevel()
    {        
        waveScore = 0;
        waveClearUI.SetActive(true);
        Time.timeScale = 0.5f;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");        
        foreach (GameObject enemy in enemies)
        {            
            if (enemy != null)
            {
                enemy.GetComponent<EnemyStats>().Remove();                
            }            
            else
                return;
        }
        GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");
        foreach (GameObject bullet in bullets)
        {
            if (bullet != null)
            {
                bullet.GetComponent<Bullet>().Remove();
            }
           else
            return;
        }
    }    
    IEnumerator NextWave()
    {
        yield return new WaitForSeconds(1f);
        waveClearUI.SetActive(false);        
        Time.timeScale = 1f;
    }
    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(1f);
        waveClearUI.SetActive(false);
        Time.timeScale = 1f;
        sceneFader.FadeTo("");
    }
}
