using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PereNoel : MonoBehaviour
{
    // La position du player
    public Transform player;
    //Bool flip sprite
    public bool flipSprite = false;

    //Fonction regarde le player
    public void LookAtPlayer()
    {
        //Scale x, y et z
        Vector3 flipped = transform.localScale;
        //La position en z
        flipped.z *= -1f;

        //Si player la position du player change
        if(transform.position.x > player.position.x && flipSprite)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            flipSprite = false;
        }else if(transform.position.x < player.position.x && !flipSprite) {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            flipSprite = true;
        }
    }
}
