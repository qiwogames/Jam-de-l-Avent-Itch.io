using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSevenCrystals : MonoBehaviour
{
    private CrystalsManager crystalsManagerScript;

    private Animator animator;

    public GameObject doorParticles;
    public AudioClip doorSound;

    public CircleCollider2D cc2d;

  
    void Start()
    {
        crystalsManagerScript = FindObjectOfType<CrystalsManager>();
        animator = GetComponent<Animator>();
        cc2d.enabled = false;
    }

  
    void Update()
    {
        //Debug.Log("Nombre de crystal " + crystalsManagerScript.nbrCrystals);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (crystalsManagerScript.nbrCrystals >= 7)
            {
                animator.SetBool("IsOpen", true);
                Invoke("LoadNextScene", 3f);
            }
        }
    }

    void LoadNextScene()
    {
        cc2d.enabled = true;
        //Debug.Log("Ok le trigger");
    }
}
