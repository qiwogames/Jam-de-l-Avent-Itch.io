using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwim : MonoBehaviour
{
    public float velocity;
    private Rigidbody2D rb2d;
    private Animator animator;

    public float moveSpeed;
    public bool isFacingRight = true;
    private float moveVelocity = 0f;

    public AudioClip jumpSound;
    public AudioClip attackSound;

    //Attack
    public GameObject playerProjectiles;
    public Transform firePoint;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        moveVelocity = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime;

        if (moveVelocity > 0)
        {
            MovesRight();
        }
        else if (moveVelocity < 0)
        {
            MovesLeft();
        }
        else
        {
            rb2d.velocity = new Vector2(0f, rb2d.velocity.y);
        }

        if (Input.GetButtonDown("Jump"))
        {
            rb2d.velocity = Vector2.up * velocity;
            animator.SetBool("canSwim", true);
            if (jumpSound)
            {
                AudioSource.PlayClipAtPoint(jumpSound, transform.position);
            }
        }

        //Stop animation de nage
        if (Input.GetButtonUp("Jump"))
        {
            animator.SetBool("canSwim", false);
        }

        if (Input.GetButtonDown("Fire1"))
        {
           
            Instantiate(playerProjectiles, firePoint.transform.position, firePoint.transform.rotation);
            if (attackSound)
            {
                AudioSource.PlayClipAtPoint(attackSound, transform.position);
            }

        }


    }

    public void MovesLeft()
    {
        rb2d.velocity = new Vector2(-moveSpeed, rb2d.velocity.y);
        isFacingRight = false;
        FlipSprites();
    }

    public void MovesRight()
    {
        rb2d.velocity = new Vector2(moveSpeed, rb2d.velocity.y);
        isFacingRight = true;
        FlipSprites();
    }

    void FlipSprites()
    {
        if (isFacingRight)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        if (!isFacingRight)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }

}
