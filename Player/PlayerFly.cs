using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFly : MonoBehaviour
{
    //vitesse du player
    public float moveSpeed; //5f en moyenne
    private Rigidbody2D rb2d;

    //Attack
    public GameObject playerProjectiles;
    public Transform firePoint;

    public AudioClip hitSound;
    public AudioClip attackSound;

    //Vector x et y
    Vector2 movement;

    //knockBack
    public float knockBack = 3f; // force x et  y  = 3
    public float knockBackCount = 0f;// = 0
    public float knockbackLenght = 0.25f;// temps 0.25s
    public bool knockFromRight;

    void Start()
    {
        rb2d= GetComponent<Rigidbody2D>();
    }

    // 60fps
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //Le tir
        //Attack
        if (Input.GetButtonDown("Fire1"))
        {
                    
            Instantiate(playerProjectiles, firePoint.transform.position, firePoint.transform.rotation);
            if (attackSound)
            {
                AudioSource.PlayClipAtPoint(attackSound, transform.position);
            }

        }
    }

    private void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
