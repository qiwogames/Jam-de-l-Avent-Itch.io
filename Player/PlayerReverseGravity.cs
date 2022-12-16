using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReverseGravity : MonoBehaviour
{

    // moves
    public float moveSpeed;
    private Rigidbody2D rbr2d;
    private float moveVelocity = 0f;
    private Animator animator;
    public bool isFacingRight = true;

    //jump
    public LayerMask whatIsGround;
    private float groundRadius = 0.1f;
    public Transform groundCheck;
    public float jumpForce = -10f;
    public bool isGrounded;
    public bool airControl = false;



    //Sounds
    public AudioClip jumpSound;
    public AudioClip attackSound;

    //Attack
    public GameObject playerProjectiles;
    public Transform firePoint;
    //Rate
    public float fireRate;
    private float lastShot = 0f;




    void Start()
    {
        rbr2d = GetComponent<Rigidbody2D>();
        rbr2d.gravityScale = -3f;
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

        //A enelever lors du build android : Application.platform == RuntimePlatform.WindowsEditor
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
            rbr2d.velocity = new Vector2(0f, rbr2d.velocity.y);
        }
    }

    void Update()
    {
        //Le saut
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }


        //Attack
        if (Input.GetButtonDown("Fire1"))
        {
            if (Time.time > fireRate + lastShot)
            {
                animator.SetBool("Attack", true);
                Invoke("StopAttackAnim", 0.2f);
                Instantiate(playerProjectiles, firePoint.transform.position, firePoint.transform.rotation);
                if (attackSound)
                {
                    AudioSource.PlayClipAtPoint(attackSound, transform.position);
                }
                lastShot = Time.time;
            }


        }


        animator.SetFloat("Speed", Mathf.Abs(rbr2d.velocity.x));
    }

    public void MovesLeft()
    {
        rbr2d.velocity = new Vector2(-moveSpeed, rbr2d.velocity.y);
        isFacingRight = false;
        FlipSprites();
    }

    public void MovesRight()
    {
        rbr2d.velocity = new Vector2(moveSpeed, rbr2d.velocity.y);
        isFacingRight = true;
        FlipSprites();
    }


    //METHODES

    public void Jump()
    {
        rbr2d.velocity = new Vector2(rbr2d.velocity.x, jumpForce);
        if (jumpSound)
        {
            AudioSource.PlayClipAtPoint(jumpSound, transform.position);
        }
    }

    void FlipSprites()
    {
        if (isFacingRight)
        {
            transform.localScale = new Vector3(1f, -1f, 1f);
        }

        if (!isFacingRight)
        {
            transform.localScale = new Vector3(-1f, -1f, 1f);
        }
    }

    void StopAttackAnim()
    {
        animator.SetBool("Attack", false);
    }


    //*****************************************************TRIGGER*********************************************************//
    //trigger ENTER : 
    void OnTriggerEnter2D(Collider2D cible)
    {
        if (cible.tag == "PlateForme")
        {
            this.transform.parent = cible.transform;
        }

        //Dans l'eau
        if (cible.tag == "Water")
        {
            animator.SetBool("Swim", true);
            moveSpeed = 3f;
        }
    }

    //Trigger STAY : colle au plateforme qui bouge
    void OnTriggerStay2D(Collider2D cible)
    {
        if (cible.tag == "PlateForme")
        {
            this.transform.parent = cible.transform;
        }
    }
    //Trigger EXIT : decolle au plateforme qui bouge
    void OnTriggerExit2D(Collider2D cible)
    {
        if (cible.tag == "PlateForme")
        {
            this.transform.parent = null;
        }
        //Hors de l'eau
        if (cible.tag == "Water")
        {
            animator.SetBool("Swim", false);
            moveSpeed = 7f;
        }

    }
}
