using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorOpen30Dollars : MonoBehaviour
{
    
    private CoinsManager coinsManager;
    private Animator animator;
    public GameObject doorParticle;

    void Start()
    {
        animator = GetComponent<Animator>();
        coinsManager = FindObjectOfType<CoinsManager>();
    }

    
    void Update()
    {
        //Debug.Log(coinsManager.coins);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(coinsManager.coins > 100)
            {
                Instantiate(doorParticle, transform.position, transform.rotation);
                animator.SetBool("isOpen", true);
                Invoke("LoadNextScene", 2f);
            }
        }
    }

    public void LoadNextScene()
    {
        Debug.Log("OK");
        SceneManager.LoadScene("Barbe");
    }
}
