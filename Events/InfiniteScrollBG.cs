
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteScrollBG : MonoBehaviour
{
    public float xPos; //-5
    public float xLimit; //12.5 soit un bg de 1024 * 768px
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(xPos * Time.deltaTime, transform.position.y,0f);
       
        //Si on atteint la limite en X
        if(transform.position.x < -xLimit)
        {
            transform.position = new Vector3(xLimit, transform.position.y,0f);
        }

    }
}
