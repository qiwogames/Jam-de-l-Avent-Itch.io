using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSingleDialogue : MonoBehaviour
{
    public GameObject pnjDialoguePanel;
    private BoxCollider2D bc2c;
    void Start()
    {
        bc2c = GetComponent<BoxCollider2D>();
        pnjDialoguePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            pnjDialoguePanel.SetActive(true);
            bc2c.enabled = false;
            Time.timeScale= 0f;
        }
    }

    public void ClosePanel()
    {
        Time.timeScale = 1f;
        pnjDialoguePanel.SetActive(false);
    }
}
