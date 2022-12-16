using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillOneShot : MonoBehaviour
{
    public GameObject deathPaticles;
    public AudioClip deathSound;

    private HealthManager healthScript;

    private void Start()
    {
        healthScript = FindObjectOfType<HealthManager>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Instantiate(deathPaticles, transform.position, transform.rotation);
            if (deathSound){
               AudioSource.PlayClipAtPoint(deathSound, transform.position);
            }
            healthScript.life = 0;
        }
    }
}
