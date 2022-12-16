using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialog : MonoBehaviour
{
    
    public Dialog dialogClass;
  

    private void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
                           
            TriggerTheDialogue();
        }
    }
    public void TriggerTheDialogue()
    {
        FindObjectOfType<DialogManager>().StartDialogue(dialogClass);
        Destroy(gameObject);
    }
}
