using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlFood : MonoBehaviour
{
    private Animator animator;
    public AudioClip foodSound;
    public GameObject plusUn;
    public GameObject ingredientsParticles;

    private int ingredientScore = 0;

    public GameObject exitDoor;

    private void Start()
    {
        exitDoor.gameObject.SetActive(false);
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pomme"))
        {
            Invoke("StopAttackAnimation", 0.5f);
            animator.SetBool("isHappy", true);
            Destroy(collision.gameObject);
            Instantiate(plusUn, new Vector3(transform.position.x, transform.position.y + 2f, 0f), Quaternion.identity);
            Instantiate(ingredientsParticles, transform.position, transform.rotation);
            if (foodSound)
            {
                AudioSource.PlayClipAtPoint(foodSound, transform.position);
            }
            ingredientScore += 1;  
        }

        if (collision.gameObject.CompareTag("Pizza"))
        {
            Invoke("StopAttackAnimation", 0.5f);
            animator.SetBool("isHappy", true);
            Destroy(collision.gameObject);
            Instantiate(plusUn, new Vector3(transform.position.x, transform.position.y + 2f, 0f), Quaternion.identity);
            Instantiate(ingredientsParticles, transform.position, transform.rotation);
            if (foodSound)
            {
                AudioSource.PlayClipAtPoint(foodSound, transform.position);
            }
            ingredientScore += 1;
        }

        if (collision.gameObject.CompareTag("Carotte"))
        {
            Invoke("StopAttackAnimation", 0.5f);
            animator.SetBool("isHappy", true);
            Destroy(collision.gameObject);
            Instantiate(plusUn, new Vector3(transform.position.x, transform.position.y + 2f, 0f), Quaternion.identity);
            Instantiate(ingredientsParticles, transform.position, transform.rotation);
            if (foodSound)
            {
                AudioSource.PlayClipAtPoint(foodSound, transform.position);
            }
            ingredientScore += 1;
        }
    }

    void StopAttackAnimation()
    {
        animator.SetBool("isHappy", false);
    }

    private void Update()
    {
        //Debug.Log("Le nombre d'ingredient" + ingredientScore);
        if(ingredientScore == 3)
        {
            exitDoor.gameObject.SetActive(true);
            
        }
    }
}
