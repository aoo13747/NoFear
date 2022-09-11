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
    public int currentWave = 1;


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
        enemySpawner.currentWave = levels[0].wave;
        levels[0].isUnlock = true;
        waveText.text = currentWave+1.ToString();
        
        //waveSlider.maxValue = levels[1].scoreToUnlock;
    }
    public void AddScore(int amount)
    {
        waveScore += amount;
        Debug.Log(waveScore);
        //waveSlider.value = waveScore;
        for (int i = 0; i < levels.Length; i++)
        {
            if (!levels[i].isUnlock && waveScore >= levels[i].scoreToUnlock)
            {
                if (levels[i].endGame)
                {
                    //StartCoroutine(EndGame());
                }
                else
                {
                    currentWave = currentWave + 1;
                    UpLevel();
                    //Debug.Log(levels[i]);

                }
                StartCoroutine(NextWave());
                enemySpawner.currentWave = levels[i].wave;
                if (i < levels.Length - 1)
                {
                    //waveSlider.minValue = waveScore;
                    //waveSlider.maxValue = levels[i + 1].scoreToUnlock;
                }

                levels[i].isUnlock = true;
                
            }
        }
    }

    void UpLevel()
    {
        Debug.Log("LEVEL UP");
        waveText.text = currentWave.ToString();
        waveScore = 0;
        waveClearUI.SetActive(true);
        Time.timeScale = 0.6f;
        //GameObject[] enemies = GameObject.FindObjectOfType<EnemyStats>
        //foreach (GameObject enemy in enemies)
        //{
        //    enemy.GetComponent<EnemyStats>().Remove();
        //}
        //GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");
        //foreach (GameObject bullet in bullets)
        //{
        //    //if (bullet != null)
        //    //    bullet.GetComponent<Bullet>().Remove();
        //    //else
        //    return;
        //}
    }
    IEnumerator NextWave()
    {
        yield return new WaitForSeconds(2f);
        waveClearUI.SetActive(false);
        Time.timeScale = 1f;
    }
}
