using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{
    public float lifetime;

    void Update()
    {
        lifetime = lifetime - Time.deltaTime;
        if (lifetime < 0)
            Destroy(gameObject);
    }
}
