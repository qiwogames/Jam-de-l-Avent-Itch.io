using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OldManQuestion : MonoBehaviour
{
    public GameObject questionPanel;
    public GameObject exitDoor;
    void Start()
    {
        exitDoor.gameObject.SetActive(false);
        questionPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            questionPanel.SetActive(true);
        }
    }
}
