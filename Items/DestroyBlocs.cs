using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBlocs : MonoBehaviour
{
    public GameObject destroyParticles;
    public AudioClip explodeSound;

    private Camera2D camera2D;


    void Start()
    {
        camera2D = FindObjectOfType<Camera2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerProjectile"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            camera2D.ShakeCamera(0.25f, 0.15f);       
            Instantiate(destroyParticles, transform.position, transform.rotation);
            if (explodeSound)
            {
                AudioSource.PlayClipAtPoint(explodeSound, transform.position);
            }
        }
    }

    void DestroyOneBloc()
    {
        
    }
}
