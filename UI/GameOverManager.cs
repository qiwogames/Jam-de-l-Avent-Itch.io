using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public void RetryGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackToMenuGame()
    {
        SceneManager.LoadScene("Accueil");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

