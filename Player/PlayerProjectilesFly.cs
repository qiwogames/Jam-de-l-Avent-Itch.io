using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectilesFly : MonoBehaviour
{
   
    public float projectileSpeed;

    private Rigidbody2D rb2d;

    public bool isFromRight = true;

    public AudioClip explodeSound;
    public GameObject projectileParticles;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //POsition du projectile
        transform.position += transform.right * Time.deltaTime * projectileSpeed;
        //Destroy(gameObject, 0.3f);
    }

    //Detruire le projectile a la collision
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
            Instantiate(projectileParticles, transform.position, transform.rotation);
            //Debug.Log("Erreur");
        }
    }

}
