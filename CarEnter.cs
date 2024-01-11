using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarEnter : MonoBehaviour
{
    public GameObject player;
    public GameObject car;
    public GameObject carCamera;

    [Header("UI to Active")]
    public GameObject UICar;
    public GameObject lightsObjects;
    public GameObject UICarIsTrigger;

    public bool canEnter;
    public bool isInside;
    // private AudioSource[] carAudio;
    public float timeLeft;
    public bool canLeave = false;

    public bool lightIsOn;

    // Start is called before the first frame update
    private void Start()
    {
        carCamera.SetActive(false);
        car.GetComponent<CarController>().enabled = false;
        car = transform.parent.gameObject;
        player = GameObject.FindGameObjectWithTag("Player");
        timeLeft = 1f;    
    }

    // Update is called once per frame
    void Update()
    {
        if(canEnter && Input.GetKeyDown(KeyCode.E))
        {
            isInside = true;

            player.transform.parent = gameObject.transform.parent;
            player.SetActive(false);

            carCamera.SetActive(true);

            car.GetComponent<CarController>() .enabled = true;

            timeLeft = 1f;

            UICar.SetActive(true);
            UICarIsTrigger.SetActive(false);
        }

        if(isInside && canLeave && Input.GetKeyDown(KeyCode.E))
        {
            player.transform.parent = null;
            player.SetActive(true);

            carCamera.SetActive(false);

            car.GetComponent<CarController>().enabled = false;

            isInside = false;
            canLeave = false;
            timeLeft = 1f;

            UICar.SetActive(false);
        }



        if(Input.GetKeyDown(KeyCode.L))
        {
            lightsObjects.SetActive(true);
        }

        if(Input.GetKeyDown(KeyCode.K))
        {
            lightsObjects.SetActive(false);
        }


        if(isInside = false && Input.GetKeyDown(KeyCode.P))
        {
            car.transform.Rotate(0.0f, 180.0f, 0.0f);
            car.transform.position = new Vector3(0f, 20.0f, 0.0f);
        }



        if(timeLeft > 0 && isInside)
        {
            timeLeft -= Time.deltaTime;
            canLeave = false;
        }else if(timeLeft <= 0 && isInside)
        {
            canLeave = true;
        }  
    }

    void OnTriggerEnter(Collider player)
    {
        canEnter = true;
        UICarIsTrigger.SetActive(true);
    }

    void OnTriggerExit(Collider player)
    {
        canEnter = false;
        UICarIsTrigger.SetActive(false);
    }
}