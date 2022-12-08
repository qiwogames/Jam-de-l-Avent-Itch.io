using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObjectsAtTime : MonoBehaviour
{
    //Temps entre 2 instances
    private float timeTillObject;
    [Range(0f, 5f)]
    //delais max entre 2 instance
    public float maxTime;//max 5f
    //temps en cours
    public float currentTime = 0f;
    //Tableau des prefabs des enemis
    public GameObject[] tableauEnemis;
    void Start()
    {
        //random en 0 et 5
        timeTillObject = Random.Range(0, maxTime);
        
    }

    // 60 fps       
    void Update()
    {
        //incremente le temps courant
        currentTime+= Time.deltaTime;
        //Si temps courant > a temps random (entre 0 et 5)
        if(currentTime > timeTillObject)
        {
            //un random entier sur la taille du tableau des prefabs
            int randomEnemies = Random.Range(0, tableauEnemis.Length);
            //Instance ramdom des enemis
            Instantiate(tableauEnemis[randomEnemies], transform.position, transform.rotation);
            //reset du timer
            timeTillObject = Random.Range(0, maxTime);
            currentTime= 0f;
        }
    }
}
