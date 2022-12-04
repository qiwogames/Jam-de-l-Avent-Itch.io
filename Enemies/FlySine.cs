using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlySine : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 5f;

    [SerializeField]
    float frequency = 20f;

    [SerializeField]
    float magnitude = 0.5f;

    bool facingRight = true;

    Vector3 pos, localScale;

    private float startPos;
    public int unitToMove;
    private float endPos;
    


    // Use this for initialization
    void Start()
    {

        pos = transform.position;
        localScale = transform.localScale;
        startPos = transform.position.x;
        endPos = startPos + unitToMove;

    }

    // Update is called once per frame
    void Update()
    {

        CheckWhereToFace();

        if (facingRight)
            MoveRight();
        else
            MoveLeft();
    }

    void CheckWhereToFace()
    {
        if (pos.x <= startPos)
            facingRight = true;

        else if (pos.x >= endPos)
            facingRight = false;

        if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
            localScale.x *= -1;

        transform.localScale = localScale;

    }

    void MoveRight()
    {
        pos += transform.right * Time.deltaTime * moveSpeed;
        transform.position = pos + transform.up * Mathf.Sin(Time.time * frequency) * magnitude;
        //Debug.Log("a gauche");
    }

    void MoveLeft()
    {
        pos -= transform.right * Time.deltaTime * moveSpeed;
        transform.position = pos + transform.up * Mathf.Sin(Time.time * frequency) * magnitude;
        //Debug.Log("a droite");
    }

}
