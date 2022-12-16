using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Princess : MonoBehaviour
{
    public GameObject heart;
    public AudioClip winSound;
    public GameObject heartParticles;

    void Start()
    {
        heart.gameObject.SetActive(false);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Instantiate(heart, transform.position, transform.rotation);
            if (winSound)
            {
                AudioSource.PlayClipAtPoint(winSound, transform.position);
            }
            heart.gameObject.SetActive(true);
            Invoke("LoadNextScene", 4f);
        }
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene("Sept");
    }
}
