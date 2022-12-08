using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedSwitch : MonoBehaviour
{
    public GameObject switchParticles;
    //Son
    public AudioClip switchSound;
    public AudioClip explodeSound;

    public GameObject redBlock;

    private Animator animator;

    private CircleCollider2D cc2d;

    void Start()
    {
        cc2d= GetComponent<CircleCollider2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            cc2d.enabled = false;
            animator.SetBool("isOn", true);
            Instantiate(switchParticles, transform.position, transform.rotation);
            if (switchSound)
            {
                AudioSource.PlayClipAtPoint(switchSound, transform.position);
            }
            Invoke("DestroyRedBlock", 1f);
        }
    }

    void DestroyRedBlock()
    {
        Instantiate(switchParticles, redBlock.transform.position,redBlock.transform.rotation);
        Destroy(redBlock);
        if (explodeSound) {
            AudioSource.PlayClipAtPoint(explodeSound, transform.position);
        }
    }
}
