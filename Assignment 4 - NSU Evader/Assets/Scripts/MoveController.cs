using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    public enum Movement
    {
        Stright,
        PointChange,
        wavey,
        follow,
        stationary
    }

    public float speed;
    public GameObject laserHit;
    public Movement movementType;
    public float pointChangeVectorX;
    [Range(0.0f, 30.0f)]
    public float waveRange;
    public Vector2 pointStop;

    private PlayerController player;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (movementType == Movement.Stright)
            rb.velocity = new Vector2(-speed, rb.velocity.y);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Instantiate(laserHit, other.transform.position, other.transform.rotation);
        //Destroy(other.gameObject);
    }
}
