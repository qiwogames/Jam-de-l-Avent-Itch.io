using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{

    //Camera
    private Camera2D cameraScript;


    private Animator animator;
    //les bonus
    public GameObject[] spawnBonus;
    private int nbrBonus = 5;
    //position
    private Transform coffrePos;
    public BoxCollider2D bc2d;
    //son
    public AudioClip openSound;

    public bool chestCanBeOpen;
    public GameObject chestParticles;

    public Transform chestPos;

    void Start()
    {
        cameraScript = FindObjectOfType<Camera2D>();
        animator = GetComponent<Animator>();
        coffrePos = GetComponent<Transform>();
        animator.SetBool("isOpen", false);
        bc2d = GetComponent<BoxCollider2D>();
        bc2d.enabled = true;
        chestCanBeOpen = false;
        if (bc2d == null)
        {
            bc2d.enabled = true;
        }
    }

    void OnTriggerEnter2D(Collider2D cible)
    {
        if (cible.gameObject.tag == "PlayerProjectile")
        {
            cameraScript.ShakeCamera(0.25f, 0.15f);
            chestCanBeOpen = true;
            if (chestCanBeOpen)
            {
                TriggerOpenChest();

            }
            else
            {
                chestCanBeOpen = false;
            }
        }
    }

    public void TriggerOpenChest()
    {
        bc2d.enabled = false;
        animator.SetBool("isOpen", true);
        Instantiate(chestParticles, transform.position, transform.rotation);
        if (openSound)
        {
            AudioSource.PlayClipAtPoint(openSound, transform.position);
        }
        bc2d.isTrigger = false;
        SpawnItems();
    }

    void SpawnItems()
    {
        //random les items
        var p = chestPos;
        for (int c = 0; c < nbrBonus; c++)
        {
            p.TransformPoint(0, 10f, 0);
            GameObject coinPrefab = Instantiate(spawnBonus[c], new Vector3(p.transform.position.x,
                p.transform.position.y + 1f, p.transform.position.z), Quaternion.identity) as GameObject;

            coinPrefab.GetComponent<Rigidbody2D>().AddForce(Vector3.right * Random.Range(-200, 100));
            coinPrefab.GetComponent<Rigidbody2D>().AddForce(Vector3.up * Random.Range(200, 200));
        }
    }
}






