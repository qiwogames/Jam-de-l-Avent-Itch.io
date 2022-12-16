using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class QuestionManager : MonoBehaviour
{
    
    public GameObject exitDoor;
    public GameObject bonneTexte;
    public GameObject mauvaiseTexte;

    public BoxCollider2D triggerOldManDialogue;

    //fx
    public GameObject doorParticles;

    //sons
    public AudioClip badSound;
    public AudioClip goodSound;

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BonneReponse()
    {
        //Debug.Log("OUI");
        triggerOldManDialogue.gameObject.SetActive(false);
        Instantiate(bonneTexte, new Vector3(1.25f, -1, 0), Quaternion.identity);
        gameObject.SetActive(false);
        if (goodSound)
        {
            AudioSource.PlayClipAtPoint(goodSound, transform.position);
        }
        exitDoor.gameObject.SetActive(true);
        Instantiate(doorParticles, exitDoor.transform.position, exitDoor.transform.rotation);
    }

    public void MauvaiseReponse()
    {
        Debug.Log("NON");
        exitDoor.gameObject.SetActive(false);
        Instantiate(mauvaiseTexte, new Vector3(1.25f, -1, 0),Quaternion.identity);
        if (badSound)
        {
            AudioSource.PlayClipAtPoint(badSound, transform.position);
        }
        gameObject.SetActive(false);
    }


}
