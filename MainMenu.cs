using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // private AudioSource click;
    void Start()
    {
        // click = GetComponent<AudioSource>();
    }

    public void PlayGame ()
    {
        SceneManager.LoadScene("Game");
        // click.Play();
    }

    public void QuitGame ()
    {
        Debug.Log("QUIT!");
        Application.Quit();
        // click.Play();
    }

}
