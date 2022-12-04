using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishLR : MonoBehaviour
{
    private float startPosition;
    private float endPosition;
    public float moveSpeed;
    public bool moveRight = true;
    public int unitToMove;

    void Start()
    {
        startPosition = transform.position.x;
        endPosition = startPosition + unitToMove;
    }

    void Update()
    {
        PlatformsMove();
    }
    void PlatformsMove()
    {
        if (moveRight)
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            transform.localScale = new Vector3(1f,1f,1f);
        }
        if (transform.position.x >= endPosition)
        {
            moveRight = false;
        }
        if (!moveRight)
        {
            transform.position -= Vector3.right * moveSpeed * Time.deltaTime;
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        if (transform.position.x <= startPosition)
        {
            moveRight = true;
        }
    }

    
}
