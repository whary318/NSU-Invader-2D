using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Misc : MonoBehaviour
{
    public enum Movement
    {
        Type1, // comment
        Type2,
        Type3
    }

    public float var1;
    public bool var2;

    [SerializeField]
    private float var3;

    public float rotation = 45f;
    [Range (0.0f, 10.0f)]
    public float range = 0.0f;

    public int[] arr1;
    public GameObject[] wave1;

    public float speedX;
    public float speedY;

    public Vector2 speed;

    public Movement movement;
}
