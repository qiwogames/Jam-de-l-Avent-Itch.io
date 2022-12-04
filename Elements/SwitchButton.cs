using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchButton : MonoBehaviour
{
    private Animator animator;
    private PlayerMoves player;
    private Camera2D camera2D;
    public DoorClose doorScript;

    public GameObject globalLight;

    private CircleCollider2D cc2d;

    public GameObject lightTexte;

    public AudioClip shakeSound;

    void Start()
    {
        player = FindObjectOfType<PlayerMoves>();
        lightTexte.gameObject.SetActive(false);
        camera2D = FindObjectOfType<Camera2D>();
        animator = GetComponent<Animator>();   
        globalLight.gameObject.SetActive(false); 

        cc2d = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D cible)
    {
        if(cible.gameObject.CompareTag("Player")){
            if (shakeSound)
            {
                AudioSource.PlayClipAtPoint(shakeSound, transform.position);
            }
            player.moveSpeed = 0f;
            cc2d.enabled = false;
            animator.SetBool("isOpen", true);
            //Shake Camera
            camera2D.ShakeCamera(0.35f, 2f);
            //Porte fermée
            doorScript.CloseDoor();
            //Timescale = 1;
            //Allumer la lumière
            globalLight.gameObject.SetActive(true);
            lightTexte.gameObject.SetActive(true);
            Invoke("ReactiveGame", 2f);
        
        }
    }

    void ReactiveGame(){
         player.moveSpeed = 7f;
         //Debug.Log("Ok");
    }
}
