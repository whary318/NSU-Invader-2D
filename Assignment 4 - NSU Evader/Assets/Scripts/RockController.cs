using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockController : MonoBehaviour
{
    public int rockHealth;
    public int rockScore;
    public enum RockType
    {
        Rock1,
        Rock2,
        Rock3,
        Rock4
    }

    public RockType type;
    public GameObject[] rocks;

    public void getHit(int demage)
    {
        rockHealth -= demage;

        if (rockHealth <= 0)
        {

            //if (type == RockType.Rock3)
            //    createRocks(2, rocks[0]);

            //else if (type == RockType.Rock4)
            //    createRocks(3, rocks[1]);

            Death();
        }
    }

    public void Death()
    {
        Debug.Log("death");
        FindObjectOfType<GameController>().IncreaseScore(rockScore);
        FindObjectOfType<GameController>().decreaseEnemy();
        Destroy(gameObject);
    }

    void createRocks(int count, GameObject rock)
    {
        for (int i = 0; i < count; i++)
        {
            Instantiate(rock, transform.position, transform.rotation);
        }
            
    }
}
