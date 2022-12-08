using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerGenericDialogue : MonoBehaviour
{

    public GameObject dialoguePanel;
    private BoxCollider2D bc2D;

    // Start is called before the first frame update
    void Start()
    {
        bc2D= GetComponent<BoxCollider2D>();
        //bc2D.enabled = true;
        dialoguePanel.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player")) {
          
            dialoguePanel.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            dialoguePanel.gameObject.SetActive(false);
            bc2D.enabled = false;
        }
    }

    //Methode public fermeture du panneau
    public void ClosePanel()
    {
        Debug.Log("Ok click");
        Time.timeScale = 1;
        dialoguePanel.SetActive(false);
        
    }


}
