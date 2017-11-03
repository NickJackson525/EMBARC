using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JourneyUIController : MonoBehaviour
{
    public GameObject[] UIElements;
    public GameObject[] buttons;
    public GameObject spaceship;
    bool pressedButton = false;

	// Use this for initialization
	void Start ()
    {
        spaceship = GameObject.FindGameObjectWithTag("Spaceship");
        UIElements = GameObject.FindGameObjectsWithTag("UI");
        buttons = GameObject.FindGameObjectsWithTag("Button");

        foreach(GameObject obj in UIElements)
        {
            if(obj.name != "Preparation")
            {
                obj.SetActive(false);
            }
        }

        foreach (GameObject obj in buttons)
        {
            obj.SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(spaceship && spaceship.GetComponent<SpaceshipMovement>().phase == 1 && !pressedButton)
        {
            foreach (GameObject obj in buttons)
            {
                if (obj.name == "BMC Button")
                {
                    obj.SetActive(true);
                }
            }
        }
    }

    public void Next()
    {
        spaceship.GetComponent<SpaceshipMovement>().NextStage();
        spaceship.GetComponent<SpaceshipMovement>().isMoving = true;

        foreach (GameObject obj in UIElements)
        {
            obj.SetActive(false);
        }
    }

    public void BMC()
    {
        foreach (GameObject obj in UIElements)
        {
            if (obj.name == "BusinessModelCanvas")
            {
                obj.SetActive(true);
            }
            else
            {
                obj.SetActive(false);
            }
        }

        foreach (GameObject obj in buttons)
        {
            if(obj.name == "BMC Button")
            {
                obj.SetActive(false);
                pressedButton = true;
            }
        }
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
