using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMap : MonoBehaviour
{
    public GameObject bigMap;

    // Start is called before the first frame update
    void Start()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            bigMap.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.M)) 
        {
            bigMap.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
