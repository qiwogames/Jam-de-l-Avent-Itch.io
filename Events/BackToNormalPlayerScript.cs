using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToNormalPlayerScript : MonoBehaviour
{
    private PlayerMoves player;
    private PlayerReverseGravity reversePlayer;
    void Start()
    {
        player = FindObjectOfType<PlayerMoves>();
        reversePlayer = FindObjectOfType<PlayerReverseGravity>();
        //player.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.enabled = true;
            player.GetComponent<Rigidbody2D>().gravityScale = 3f;
            reversePlayer.enabled = false;
        }

    }


}

