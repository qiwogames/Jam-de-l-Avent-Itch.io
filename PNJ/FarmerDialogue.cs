using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmerDialogue : MonoBehaviour
{
    public GameObject farmerPanel;

    void Start()
    {
        farmerPanel.gameObject.SetActive(false);
      
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")){
            farmerPanel.gameObject.SetActive(true);
            
        }
    }

    public void CloseFarmerPanel()
    {
        farmerPanel.gameObject.SetActive(false);
    }
}
