using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetLegumes : MonoBehaviour
{

    
    public int nbrLegumes = 0;

    public GameObject exitDoor;

    public GameObject legumesParticles;
    public AudioClip legumesSound;

 
    // Start is called before the first frame update
    void Start()
    {
       
        exitDoor.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (nbrLegumes == 8)
        {
            exitDoor.gameObject.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Legumes"))
        {
            nbrLegumes += 1;
            Destroy(collision.gameObject);
            Instantiate(legumesParticles, transform.position, transform.rotation);
            if (legumesSound)
            {
                AudioSource.PlayClipAtPoint(legumesSound, transform.position);
            }
        }
    }
}
