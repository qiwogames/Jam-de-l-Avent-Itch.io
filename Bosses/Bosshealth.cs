using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bosshealth : MonoBehaviour
{
 
    //La vie
    public int maxHealth = 10;
    public int health = 10;

    //la physique
    private Rigidbody2D rb2d;

    //Les bonus
    public GameObject[] spanBonus;
    public int nombreBonus = 10;

    //La camera
    private Camera2D camera2D;

    //Porte de sortie
    public GameObject exitDoor;
    

    //fx
    public GameObject damageParticles;
    public Material hitEnemy;
    public Material defaultHitEnemy;
    //Le son
    public AudioClip hitSound;
    public AudioClip explodeSound;
    //Le slider
    public HealthBar healthBar;
    //Le boss
    public GameObject enemy;
    public Transform enemyPos;

    void Start()
    {
        exitDoor.SetActive(false);
        camera2D = FindObjectOfType<Camera2D>();
        rb2d = GetComponent<Rigidbody2D>();
        health = maxHealth;
        healthBar.BossMaxHealth(maxHealth);
    }

    public IEnumerator HitDelayEnemy()
    {
        yield return new WaitForSeconds(0.1f);
        enemy.GetComponent<SpriteRenderer>().material = hitEnemy;
        yield return new WaitForSeconds(0.1f);
        enemy.GetComponent<SpriteRenderer>().material = defaultHitEnemy;
        yield return new WaitForSeconds(0.1f);
        enemy.GetComponent<SpriteRenderer>().material = hitEnemy;
        yield return new WaitForSeconds(0.1f);
        enemy.GetComponent<SpriteRenderer>().material = defaultHitEnemy;
        yield return new WaitForSeconds(0.1f);
        enemy.GetComponent<SpriteRenderer>().material = hitEnemy;
        yield return new WaitForSeconds(0.1f);
        enemy.GetComponent<SpriteRenderer>().material = defaultHitEnemy;
        yield return new WaitForSeconds(0.1f);
        enemy.GetComponent<SpriteRenderer>().material = hitEnemy;
        yield return new WaitForSeconds(0.1f);
        enemy.GetComponent<SpriteRenderer>().material = defaultHitEnemy;
        yield return new WaitForSeconds(0.1f);
        enemy.GetComponent<SpriteRenderer>().material = hitEnemy;
        yield return new WaitForSeconds(0.1f);
        enemy.GetComponent<SpriteRenderer>().material = defaultHitEnemy;

    }


    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            health = 0;
            Destroy(gameObject);
            camera2D.ShakeCamera(0.25f, 0.15f);
            SpawnBonus();
            if (explodeSound)
            {
                AudioSource.PlayClipAtPoint(explodeSound, transform.position);
            }
            exitDoor.SetActive(true);
        }
    }

    void SpawnBonus()
    {
        var p = enemyPos;
        for(int b = 0; b < nombreBonus; b++)
        {
            p.TransformPoint(0, 10f, 0);
            GameObject coinPrefab = Instantiate(spanBonus[b], new Vector3(p.transform.position.x,
               transform.position.y + 1f, p.transform.position.z), Quaternion.identity) as GameObject;
            //La force
            coinPrefab.GetComponent<Rigidbody2D>().AddForce(Vector3.right * Random.Range(-200, 100));
            coinPrefab.GetComponent<Rigidbody2D>().AddForce(Vector3.up * Random.Range(200, 200));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerProjectile"))
        {
            Destroy(collision.gameObject);
            Instantiate(damageParticles, transform.position, transform.rotation);
            if (hitSound)
            {
                AudioSource.PlayClipAtPoint(hitSound, transform.position);
            }
            TakeDamage();
        }
    }

    void TakeDamage()
    {
        health -= 1;
        StartCoroutine(HitDelayEnemy());
        //Mise a jour du slider
        healthBar.SetHealth(health);
    }
}
