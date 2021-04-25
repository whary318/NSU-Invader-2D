using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Range(0.0f, 3.0f)]
    public float spawnEvery;
    private float spawnRateDelta;

    public Transform upperLimit;
    public Transform lowerLimit;

    public GameObject[] enemyTypes;
    public GameObject[] rockTypes;

    private bool isSpawnLeft = false;
    private int wave;
    private int spawnAmountLeft;


    void Start()
    {
        spawnRateDelta = spawnEvery;
    }

    void Update()
    {
        if (isSpawnLeft)
        {
            spawnRateDelta -= Time.deltaTime;
            if (spawnRateDelta <= 0)
            {
                spawnRateDelta = spawnEvery;
                
                if (wave == 1)
                    spawnRocks();
                else if (wave == 2)
                    spawnEnemy1();
                else if (wave == 3)
                    spawnEnemy2();
                else if (wave == 4)
                    spawnEnemyDisk();
                else if (wave >= 5 && wave <= 9)
                {
                    spawnEnemy1();
                    spawnEnemyDisk();
                }
                else if (wave == 0) // meaning it is wave 10
                    spawnEnemyBoss();

                spawnAmountLeft--;
            }

            if (spawnAmountLeft <= 0)
                isSpawnLeft = false;
        }

    }

    public void spawnWave(int wave)
    {
        spawnAmountLeft = 10 + wave * 3;
        if (wave > 9)
            wave %= 10;
        isSpawnLeft = true;
        this.wave = wave;
        FindObjectOfType<GameController>().increaseEnemy(spawnAmountLeft);
    }

    private void spawnRocks()
    {
        Instantiate(rockTypes[Random.Range(0, 4)], new Vector3(upperLimit.position.x, Random.Range(lowerLimit.position.y, upperLimit.position.y), 0), upperLimit.rotation);
    }
    private void spawnEnemy1()
    {
        Instantiate(enemyTypes[0], new Vector3(upperLimit.position.x, Random.Range(lowerLimit.position.y, upperLimit.position.y), 0), upperLimit.rotation);
    }
    private void spawnEnemy2()
    {
        Instantiate(enemyTypes[1], new Vector3(upperLimit.position.x, Random.Range(lowerLimit.position.y, upperLimit.position.y), 0), upperLimit.rotation);
    }
    private void spawnEnemyDisk()
    {
        Instantiate(enemyTypes[2], new Vector3(upperLimit.position.x, Random.Range(lowerLimit.position.y, upperLimit.position.y), 0), upperLimit.rotation);
    }
    private void spawnEnemyBoss()
    {
        Instantiate(enemyTypes[3], new Vector3(upperLimit.position.x, Random.Range(lowerLimit.position.y, upperLimit.position.y), 0), upperLimit.rotation);
    }
}
