using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SurveyCreator : MonoBehaviour
{
    public InputField nameField;
    public InputField categoryField;
    
    //private string surveyName;
    //private string categoryName;
    public Text nameText;
    public Text categoryText;
    
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void setget()
    {
        nameText.text = nameField.text;
        categoryText.text = categoryField.text;
        
    }

    /*public void OnSubmit()
    {
        surveyName = nameField.text;
        categoryName = categoryField.text;
        Debug.Log("You selected " + surveyName);
        Debug.Log("You selected " + categoryName);

    }*/

}
