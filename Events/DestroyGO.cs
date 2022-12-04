using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGO : MonoBehaviour
{
    public float delayBeforeDestroy;
    

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, delayBeforeDestroy);
    }
}
