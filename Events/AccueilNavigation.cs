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
    //Options
    public void OptionsScene()
    {
        SceneManager.LoadScene("Options");
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

    //Mensonges
    public void MensongesScene()
    {
        SceneManager.LoadScene("Mensonges");
    }

    //Table
    public void TableScene()
    {
        SceneManager.LoadScene("Table");
    }
    //WakeUp
    public void WakeUpScene()
    {
        SceneManager.LoadScene("WakeUp");
    }

    //Shoes
    public void ShoesScene()
    {
        SceneManager.LoadScene("Shoes");
    }
    //Amour
    public void AmourScene()
    {
        SceneManager.LoadScene("Amour");
    }

    //Barbe
    public void BarbeScene()
    {
        SceneManager.LoadScene("Barbe");
    }

    //Poison
    public void PoisonScene()
    {
        SceneManager.LoadScene("Poison");
    }

    //Charmant
    public void CharmantScene()
    {
        SceneManager.LoadScene("Charmant");
    }

    //Sept
    public void SeptScene()
    {
        SceneManager.LoadScene("Sept");
    }

    //Legumes
    public void LegumesScene()
    {
        SceneManager.LoadScene("Legumes");
    }

    //Lampe
    public void LampeScene()
    {
        SceneManager.LoadScene("Lampe");
    }

    //Fort
    public void FortScene()
    {
        SceneManager.LoadScene("Fort");
    }

    //Quitter
#if UNITY_EDITOR || UNITY_STANDALONE
    public void QuitGame()
    {
        Application.Quit();
    }
#endif
}
