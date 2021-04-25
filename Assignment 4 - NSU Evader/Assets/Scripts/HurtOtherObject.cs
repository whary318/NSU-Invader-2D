using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtOtherObject : MonoBehaviour
{
    public int damageAmount;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            FindObjectOfType<GameController>().HurtPlayer(damageAmount);

        else if (other.gameObject.CompareTag("Enemy"))
            other.gameObject.GetComponent<EnemyController>().getHit(damageAmount);

        else if (other.gameObject.CompareTag("Rock"))
            other.gameObject.GetComponent<RockController>().getHit(damageAmount);
    }
}
