using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCreator : MonoBehaviour
{
    public GameObject blackLinePrefab;
    public GameObject whiteLinePrefab;
    public GameObject[] allLines;

    Line activeLine;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject lineGO = Instantiate(blackLinePrefab);
            activeLine = lineGO.GetComponent<Line>();
        }

        if (Input.GetMouseButtonUp(0))
        {
            activeLine = null;
        }

        if (Input.GetMouseButtonDown(1))
        {
            GameObject lineGO = Instantiate(whiteLinePrefab);
            activeLine = lineGO.GetComponent<Line>();
        }

        if (Input.GetMouseButtonUp(1))
        {
            activeLine = null;
        }

        if (activeLine != null)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            activeLine.UpdateLine(mousePos);
        }
       
        if(Input.GetKeyUp(KeyCode.Delete))
        {
            allLines = GameObject.FindGameObjectsWithTag("Line");

            foreach(GameObject line in allLines)
            {
                Destroy(line);
            }
        }
	}
}
