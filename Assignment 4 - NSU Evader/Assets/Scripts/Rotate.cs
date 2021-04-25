using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float speed;

    [Range(0.0f, 20.0f)]
    public float range = 0.0f;
 
    void Update()
    {
        transform.Rotate(0, 0, (speed + range) * Time.deltaTime);
    }
}
