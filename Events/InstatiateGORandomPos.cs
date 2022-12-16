using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstatiateGORandomPos : MonoBehaviour
{
    public GameObject rockBounce;
    public Transform[] rockPos;
    public float spawnTime;


    void Start()
    {
        InvokeRepeating("SpawnRock", 0, spawnTime);       
    }

    void SpawnRock()
    {
        int rockIndex = Random.Range(0, rockPos.Length);
        Instantiate(rockBounce, rockPos[rockIndex].position, rockPos[rockIndex].rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
