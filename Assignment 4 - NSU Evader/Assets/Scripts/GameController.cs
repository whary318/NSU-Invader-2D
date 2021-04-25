using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int health = 3;
    private int wave = 0;
    private int score = 0;
    private int enemyCount = 0;
    //public GameObject enemySpawner;
    public GameObject gameOver;
    public Text scoreText;
    public Text healthText;
    public Text waveText;
    public Text enemyCounterText;


    // Start is called before the first frame update
    void Start()
    {
        gameOver.SetActive(false);

        scoreText.text = "Score: " + score;
        waveText.text = "Wave: " + wave;
        healthText.text = "Health: " + health;
        enemyCounterText.text = "Enemies Left: " + enemyCount;

        NextWave();
    }

    void Update()
    {

    }

    public void HurtPlayer(int damage)
    {
        health -= damage;
        healthText.text = "Health: " + health;

        if (health <= 1)
        {
            if (health <= 0)
            {
                Time.timeScale = 0.0f;
                gameOver.gameObject.SetActive(true);
            }
        }

    }

    public void IncreaseScore(int scoreIncrease)
    {
        score += scoreIncrease;
        scoreText.text = "Score: " + score;
    }
    public void decreaseEnemy()
    {
        enemyCount--;
        enemyCounterText.text = "Enemies Left: " + enemyCount;
        if (enemyCount <= 0)
        {
            enemyCount = 0;
            NextWave();
        }
    }
    public void increaseEnemy(int amount)
    {
        enemyCount = amount;
        enemyCounterText.text = "Enemies Left: " + enemyCount;
        Debug.Log("increaseEnemy - " + amount);
    }

    public void NextWave()
    {
        wave++;
        waveText.text = "Wave: " + wave;
        FindObjectOfType<EnemySpawner>().spawnWave(wave);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Level 1", LoadSceneMode.Single);
        Time.timeScale = 1.0f;
    }
}
