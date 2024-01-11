using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetourMenu : MonoBehaviour
{

    [Header("Retour Menu boi")]
    public bool retourMenu = false;
    
    // Start is called before the first frame update
    void Start()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RetourMainMenu();
            retourMenu = true;
            Debug.Log("QUIT!");
        } else
        {
            retourMenu = false;
        }
    }

    public void RetourMainMenu()
    {
        SceneManager.LoadScene("Menu");
        Debug.Log("QUIT!");
    }
}
