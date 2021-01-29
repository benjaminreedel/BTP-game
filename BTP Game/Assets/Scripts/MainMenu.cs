using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void play() {
        SceneManager.LoadScene(2);
        PlayerStats.Energy = 300;
    }

    public void options() {
        SceneManager.LoadScene(1);
    }

    public void quit() {
        Application.Quit ();
    }
}
