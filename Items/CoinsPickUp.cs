using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsPickUp : MonoBehaviour
{
    //Coin manager
    private CoinsManager coinScript;

    //Son
    public AudioClip coinSound;
    public GameObject coinsParticles;


    void Start()
    {
        coinScript = FindObjectOfType<CoinsManager>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            coinScript.addCoins();
            Instantiate(coinsParticles, transform.position, transform.rotation);
            if (coinSound)
            {
                AudioSource.PlayClipAtPoint(coinSound, transform.position);
            }
            Destroy(gameObject);
        }
    }
}