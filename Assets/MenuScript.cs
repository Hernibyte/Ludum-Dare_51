using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public AudioSource musicMenu, CreditsMenu;

    public void startMenuMusic()
    {
        musicMenu.Play();
    }
    public void stopMenuMusic()
    {
        musicMenu.Stop();
    }

    public void startCreditsMusic()
    {
        CreditsMenu.Play();
    }
    public void stopCreditsMusic()
    {
        CreditsMenu.Stop();
    }

    public void StartScene()
    {        
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
