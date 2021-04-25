using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour
{
    public float speed;
    private Renderer rend;


    void Start()
    {
        rend = GetComponent<Renderer>();
    }


    void Update()
    {
        float offset = Time.time * -speed; //Time.deltaTime * -speed;
        //Debug.Log(Time.time);
        //Debug.Log(Time.deltaTime);
        rend.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));

    }
}
