using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class BMC_Controller : MonoBehaviour
{
    public GameObject BMCPopup;
    public Sprite BMC1;
    public Sprite BMC2;
    public Sprite BMC3;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKeyUp(KeyCode.Escape) && BMCPopup.activeSelf)
        {
            BMCPopup.SetActive(false);
        }
	}

    public void ChangeBMC(GameObject BMC)
    {
        if(BMC.GetComponent<SpriteRenderer>().sprite == BMC1)
        {
            BMC.GetComponent<SpriteRenderer>().sprite = BMC2;
        }
        else if (BMC.GetComponent<SpriteRenderer>().sprite == BMC2)
        {
            BMC.GetComponent<SpriteRenderer>().sprite = BMC3;
        }
        else
        {
            BMC.GetComponent<SpriteRenderer>().sprite = BMC1;
        }
    }
}
