using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;

    public GameObject crossAir;
    public GameObject healthBar;
    public GameObject miniMap;
    
    public static bool GameIsPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            } 
            else
            {
                Pause();
            }
        }    
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        crossAir.SetActive(false);
        healthBar.SetActive(false);
        miniMap.SetActive(false);
        // Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        crossAir.SetActive(true);
        healthBar.SetActive(true);
        miniMap.SetActive(true);
        // Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("Menu");
    }
}

