using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorClose : MonoBehaviour
{
    private Animator animator;

    public bool isClosed = false;

    void Start()
    {
        animator = GetComponent<Animator>();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseDoor(){
        animator.SetBool("isClosed", true);
    }
}
