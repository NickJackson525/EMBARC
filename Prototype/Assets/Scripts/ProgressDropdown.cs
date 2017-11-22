using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressDropdown : MonoBehaviour
{
    public GameObject panel;
    public int timer = 0;
    bool openDropdown = false;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(timer > 0)
        {
            timer--;
        }

		if(openDropdown)
        {
            if(panel.transform.localScale.y < 1)
            {
                if(timer % 2 == 0)
                {
                    panel.transform.localScale = new Vector3(panel.transform.localScale.x, panel.transform.localScale.y + .1f, panel.transform.localScale.z);

                    if (panel.transform.localScale.y < 0)
                    {
                        panel.transform.localScale = new Vector3(panel.transform.localScale.x, 1, panel.transform.localScale.z);
                    }
                }
            }
        }
        else
        {
            if(panel.transform.localScale.y > 0)
            {
                if (timer % 2 == 0)
                {
                    panel.transform.localScale = new Vector3(panel.transform.localScale.x, panel.transform.localScale.y - .1f, panel.transform.localScale.z);

                    if(panel.transform.localScale.y < 0)
                    {
                        panel.transform.localScale = new Vector3(panel.transform.localScale.x, 0, panel.transform.localScale.z);
                    }
                }
            }
        }
	}

    private void OnMouseEnter()
    {
        openDropdown = true;
        timer = 30;
    }

    private void OnMouseExit()
    {
        openDropdown = false;
        timer = 30;
    }
}
