using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlide : MonoBehaviour
{
    private PlayerMoves player;

    void Start()
    {
        player = GetComponentInParent<PlayerMoves>();
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall") && player.transform.position.y > 0)
        {
            player.isGrounded = false;
            //Debug.Log("Touche le mur");
        }
    }
}
