using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UICanvasController : MonoBehaviour
    
{
    public GameObject[] Canvases = new GameObject[14];
       
	// Use this for initialization
	void Start ()
    {
        Canvases = GameObject.FindGameObjectsWithTag("Canvas");
        foreach(GameObject canvas in Canvases)
        {
            if(canvas.name != "MainMenu")
            {
                canvas.SetActive(false);
            }
        }

    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadCanvas(string canvasName)
    {
        foreach(GameObject canvas in Canvases)
        {
            if(canvas.name == canvasName)
            {
                canvas.SetActive(true);
            }
            else
            {
                canvas.SetActive(false);
            }
        }
    }
}
