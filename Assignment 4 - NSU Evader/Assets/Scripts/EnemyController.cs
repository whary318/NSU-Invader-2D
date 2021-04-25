using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public enum EnemyType
    {
        Enemy1,
        Enemy2,
        Disk,
        Boss
    }
    public EnemyType enemyType;

    public int enemyHealth;
    public int enemyScore;

    public GameObject laserBullet;
    public Transform[] firePoint;

    [Range(0, 2)]
    public float fireRate;
    private float fireRateDelta;

    // Start is called before the first frame update
    void Start()
    {
        fireRateDelta = fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        //fire bullet at set time
        fireRateDelta -= Time.deltaTime;
        if(fireRateDelta <= 0)
        {
            FireBullet();
            fireRateDelta = fireRate;
        }

    }

    void FireBullet()
    {
        for(int i = 0; i < firePoint.Length; i++)
            Instantiate(laserBullet, firePoint[i].position, firePoint[i].rotation);
    }

    public void getHit(int demage)
    {
        enemyHealth -= demage;

        if(enemyHealth <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        FindObjectOfType<GameController>().IncreaseScore(enemyScore);
        FindObjectOfType<GameController>().decreaseEnemy();
        Destroy(gameObject);
    }

    
}
