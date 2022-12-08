using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFromLeft : MonoBehaviour
{
    public float moveSpeed; //5f

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        pos.z = -2f;
        pos.x -= moveSpeed * Time.fixedDeltaTime;

        transform.position = pos;
        Destroy(gameObject, 10f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("test");
            
        }
    }
}
