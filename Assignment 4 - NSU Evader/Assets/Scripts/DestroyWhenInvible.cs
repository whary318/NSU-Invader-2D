using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWhenInvible : MonoBehaviour
{
    public void OnBecameInvisible()
    {
        if (!gameObject.CompareTag("PlayerLaser") && !gameObject.CompareTag("EnemyLaser"))
        {
            FindObjectOfType<GameController>().decreaseEnemy();
        }
        
        Destroy(gameObject);
    }
}
