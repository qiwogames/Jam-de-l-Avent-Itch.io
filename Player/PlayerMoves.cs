using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoves : MonoBehaviour
{
    // moves
    public float moveSpeed;
    private Rigidbody2D rbr2d;
    private float moveVelocity = 0f;
    private Animator animator;
    public bool isFacingRight = true;

    //jump
    public LayerMask whatIsGround;
    private float groundRadius = 0.2f;
    public Transform groundCheck;
    public float jumpForce;
    public bool isGrounded;
    public bool airControl = false;



    //knockBack
    public float knockBack = 3f; // force x et  y  = 3
    public float knockBackCount = 0f;// = 0
    public float knockbackLenght = 0.25f;// temps 0.25s
    public bool knockFromRight;


    //Sounds
    public AudioClip jumpSound;
    public AudioClip attackSound;

    //Attack
    public GameObject playerProjectiles;
    public Transform firePoint;




    void Start()
    {
        rbr2d = GetComponent<Rigidbody2D>();
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
            animator.SetBool("Attack", true);
            Invoke("StopAttackAnim", 0.2f);
            Instantiate(playerProjectiles, firePoint.transform.position, firePoint.transform.rotation);
            if (attackSound)
            {
                AudioSource.PlayClipAtPoint(attackSound, transform.position);
            }

        }



        //knockback droite et gauche
        if (knockBackCount <= 0)
        {
            rbr2d.velocity = new Vector2(rbr2d.velocity.x, rbr2d.velocity.y);
        }
        else
        {
            if (knockFromRight)
            {
                rbr2d.velocity = new Vector2(-knockBack, knockBack);
            }
            if (!knockFromRight)
            {
                rbr2d.velocity = new Vector2(knockBack, knockBack);
            }
            knockBackCount -= Time.deltaTime;
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

    public void Attack()
    {

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
        if(cible.tag == "Water")
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
