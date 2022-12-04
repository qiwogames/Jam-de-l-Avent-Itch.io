using System.Diagnostics.Contracts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AccueilNavigation : MonoBehaviour
{
    //Accueil
    public void AccueuilScene(){
        SceneManager.LoadScene("Accueil");
    }

    //Rocher

    public void RocherScene(){
        SceneManager.LoadScene("Rocher");
    }

    //Lac
    public void LacScene()
    {
        SceneManager.LoadScene("Lac");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
