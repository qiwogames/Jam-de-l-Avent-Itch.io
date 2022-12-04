using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    public AudioClip explodeSound;
    //fx
    public GameObject explodeParticle;
    private HealthManager healthScript;




    void Start()
    {
        healthScript = FindObjectOfType<HealthManager>();
    }



    //Contact avec le player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.SetActive(false);
            healthScript.life = 0;
            Instantiate(explodeParticle, transform.position, transform.rotation);
            if (explodeSound)
            {
                AudioSource.PlayClipAtPoint(explodeSound, transform.position);
            }

        }
    }
}