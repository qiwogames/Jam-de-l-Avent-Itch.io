using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ScieLR : MonoBehaviour
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
        transform.Rotate(new Vector3(0, 0, 180) * Time.deltaTime);
    }
    void PlatformsMove()
    {
        if (moveRight)
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        }
        if (transform.position.x >= endPosition)
        {
            moveRight = false;
        }
        if (!moveRight)
        {
            transform.position -= Vector3.right * moveSpeed * Time.deltaTime;
        }
        if (transform.position.x <= startPosition)
        {
            moveRight = true;
        }
    }
}

