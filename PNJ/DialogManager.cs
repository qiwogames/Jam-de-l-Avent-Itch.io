using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    //Afficher le nom et les phrase dans le panneau
    public Text nomText;
    public Text dialogueText;
    //Les elements a manipuler a la fin du dialogue
    public BoxCollider2D triggerBc2D;
    public Animator oldManAnimator;
    public GameObject exitDoor;
    public GameObject doorParticles;
    public AudioClip doorSound;
    public Animator anim;

    // Queue utilise une tableau de string FIFO (First In First Out)
    public Queue<string> sentences;

    void Start()
    {
        sentences = new Queue<string>();
        exitDoor.gameObject.SetActive(false);
       
    }

    public void StartDialogue(Dialog dialogue)
    {
        anim.SetBool("isOpen", true);
        //Time.timeScale = 0;
        //Debug.Log("Test du nom" + dialogue.nom);
        nomText.text = dialogue.nom;
        //Test de la phrase 1
        //dialogueText.text = dialogue.sentences[0];
        sentences.Clear();

        //Boucle de parcours du tableau de phrase
        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        //DisplayNextSentence();
    }

    //Trigger la phrase suivante
    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        //Fin du tableau
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        //Debug.Log(sentence);
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;  
        }
    }

    public void EndDialogue()
    {
        //Debug.Log("Fin du dialogue");
        anim.SetBool("isOpen", false);
        triggerBc2D.enabled = false;
        oldManAnimator.SetBool("isHappy", true);
        //SON
        if (doorSound)
        {
            AudioSource.PlayClipAtPoint(doorSound, transform.position);
        }
        Instantiate(doorParticles, transform.position, transform.rotation);
        exitDoor.gameObject.SetActive(true);
        Time.timeScale = 1;
    }
}
