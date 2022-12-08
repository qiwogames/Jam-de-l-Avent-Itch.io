using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WakeUp : MonoBehaviour
{
    public GameObject playerSleep;
    public GameObject player;
    public Camera2D camera2D;

    public GameObject fxParticles;
    public AudioClip wakeUpSound;


    void Start()
    {
        camera2D = FindObjectOfType<Camera2D>();
        player.gameObject.SetActive(false);
        Invoke("StartScenneFx", 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartScenneFx()
    {
        camera2D.ShakeCamera(0.25f, 1.2f);
        Instantiate(fxParticles, new Vector3(-5f, -2f, 0f), Quaternion.identity);
        if (wakeUpSound)
        {
            AudioSource.PlayClipAtPoint(wakeUpSound, transform.position);
        }
        Destroy(playerSleep.gameObject);
        player.gameObject.SetActive(true);
    }
}
