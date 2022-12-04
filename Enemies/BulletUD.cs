using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletUD : MonoBehaviour
{
    private float startPos;
    private float endPos;
    public float moveSpeed;
    public int unitToMove;

    public bool moveUp = true;

    void Start()
    {
        startPos = transform.position.y;
        endPos = startPos + unitToMove;
    }

    
    void Update()
    {
        transform.position += Vector3.up * moveSpeed;
        if(transform.position.y >= endPos)
        {
            moveUp = false;
        }
        if (!moveUp)
        {
            transform.position -= Vector3.up * 0.01f;
        }
        if (transform.position.y <= startPos)
        {
            moveUp = true;
        }

    }

    void UpDownBullet()
    {
        if(moveUp)
        {
            transform.position += Vector3.up * moveSpeed;
        }
    }
}
