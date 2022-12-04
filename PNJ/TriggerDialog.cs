using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialog : MonoBehaviour
{
    
    public Dialog dialogClass;
    //Appel de la classe dialog serilazé + non monobehaviour
 


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Time.timeScale = 0;         
            TriggerTheDialogue();
        }
    }
    public void TriggerTheDialogue()
    {
        FindObjectOfType<DialogManager>().StartDialogue(dialogClass);
    }
}
