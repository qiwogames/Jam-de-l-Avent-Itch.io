using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystals : MonoBehaviour
{
    public GameObject crystalParticles;
    public AudioClip crystalSound;

    private CrystalsManager crystalsManagerScript;
    void Start()
    {
        crystalsManagerScript = FindObjectOfType<CrystalsManager>();
    }

  
    void Update()
    {
        //Debug.Log(crystalsManagerScript.nbrCrystals);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            Instantiate(crystalParticles, transform.position, transform.rotation);
            if (crystalSound)
            {
                AudioSource.PlayClipAtPoint(crystalSound, transform.position);
            }

            crystalsManagerScript.addCrystal();

        }
    }

}
