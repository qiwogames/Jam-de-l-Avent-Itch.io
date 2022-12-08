using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PickUpShoesItem : MonoBehaviour
{
    private GameObject player;

    public GameObject itemParticles;
    public AudioClip itemSound;

    public GameObject newPlayer;

    public bool loadNextScene = false;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }



    void SceneSuivante()
    {    
        //Debug.Log("Test de coroutine");
        SceneManager.LoadScene("Shoes");
    }



    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            Instantiate(itemParticles, transform.position, transform.rotation);
            if (itemSound)
            {
                AudioSource.PlayClipAtPoint(itemSound, transform.position);
            }
            Instantiate(newPlayer, new Vector3(transform.position.x, transform.position.y + 0.3f, 0f),Quaternion.identity);
            player.gameObject.SetActive(false);
            Invoke("SceneSuivante", 3f);
            gameObject.SetActive(false);
            
        }
    }

  
    void Update()
    {
     
    }


}
