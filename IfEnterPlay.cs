using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IfEnterPlay : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            GoGame();
        }
    }

    public void GoGame()
    {
        SceneManager.LoadScene("Game");
    }
}
