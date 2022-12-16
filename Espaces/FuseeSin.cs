using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuseeSin : MonoBehaviour
{

    float sinCenterY;

    public float sineAmplitude; //2f amplitude de la courbe sinusoiadale
    public float frequence; //frequence de modification de la courbe Sin = 0.5f

    //incerser la courbe sin
    public bool inverted = false;
    
    void Start()
    {
        sinCenterY = transform.position.y;
    }

    // 60fps
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;

        float sin = Mathf.Sin(pos.x * frequence) * sineAmplitude;
        if (inverted)
        {
            sin *= -1;
        }
        pos.y = sinCenterY + sin;
        

        transform.position = pos;
    }
}
