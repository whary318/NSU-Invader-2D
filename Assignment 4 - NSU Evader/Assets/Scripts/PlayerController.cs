using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Animator anim;

    public GameObject laserBullet;
    public GameObject laserHit;
    public Transform firePoint;

    public Transform topLeft;
    public Transform bottomRight;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        

    }

    // Update is called once per frame
    void Update()
    {
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb.velocity = moveInput * speed;
        anim.SetFloat("Movement", Input.GetAxisRaw("Vertical"));


        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, topLeft.position.x, bottomRight.position.x),
            Mathf.Clamp(transform.position.y, bottomRight.position.y, topLeft.position.y),
            transform.position.z
            );
        

        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(laserBullet, firePoint.position, firePoint.rotation);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Instantiate(laserHit, other.transform.position, other.transform.rotation);
        Destroy(other.gameObject);
    }
}
