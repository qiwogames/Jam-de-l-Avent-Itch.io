using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootFromUp : MonoBehaviour
{
    private Animator animator;
    public AudioClip shootSound;
    public GameObject enemyProjectile;
    public GameObject projectileParticles;
    public bool canShot = false;
    public Transform firePoint;

    [Range(2f, 5f)]
    public int repeatFunctionDelay;
    void Start()
    {
        animator= GetComponent<Animator>();
        InvokeRepeating("Attack", 0f, repeatFunctionDelay);
    }



    public void Attack()
    {
        //Debug.Log("Toutes les 2s");
            animator.SetBool("Attack", true);
            Instantiate(enemyProjectile, firePoint.transform.position, firePoint.transform.rotation);
          
        Invoke("StopAttack", .5f);


    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    void StopAttack()
    {
        animator.SetBool("Attack", false);
       
    }
}
