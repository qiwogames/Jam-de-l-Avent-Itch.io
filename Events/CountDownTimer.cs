using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour
{
    public float tempsRestant;
    public bool timerDemarrer = false;
    public Text timerTexte;
    public GameObject panneauLaSuite;
    void Start()
    {
        panneauLaSuite.gameObject.SetActive(false);
        timerDemarrer= true;
    }

    // Update is called once per frame
    void Update()
    {
        if(timerDemarrer)
        {
            if(tempsRestant > 0)
            {
                tempsRestant -= Time.deltaTime;
                updateTimer(tempsRestant);
            }
            else
            {
                Debug.Log("C terminer");
                tempsRestant = 0f;
                timerDemarrer = false;

                //Change de niveau
                StopGame();
            }
        }
    }

    //mise a jour du timer
    void updateTimer(float tempEnCours)
    {
        tempEnCours += 1f;

        float minutes = Mathf.FloorToInt(tempEnCours / 60);
        float secondes = Mathf.FloorToInt(tempEnCours % 60);

        //Afficher a l'ecan
        timerTexte.text = string.Format("{0:00} : {1:00}", minutes, secondes);
    }

    void StopGame()
    {
        Time.timeScale = 0;
        panneauLaSuite.gameObject.SetActive(true);
    }
}
