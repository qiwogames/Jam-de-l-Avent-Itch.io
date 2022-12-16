using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestCrystals : MonoBehaviour
{
    public AudioClip openSound;
    public GameObject chestParticles;

    public GameObject crystals;
    private Animator animator;

    private CircleCollider2D cc2d;


    void Start()
    {
        animator = GetComponent<Animator>();
        cc2d = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerProjectile"))
        {
            cc2d.enabled = false;
            animator.SetBool("IsOpen", true);
            Instantiate(chestParticles, transform.position, transform.rotation);
            Instantiate(crystals, new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z), Quaternion.identity);
            if (openSound)
            {
                AudioSource.PlayClipAtPoint(openSound, transform.position);
            }
        }
    }
}
