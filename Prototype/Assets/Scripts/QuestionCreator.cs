using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionCreator : MonoBehaviour
{
    public InputField questionOne;
    public InputField questionTwo;
    public Text qOneText;
    public Text qTwoText;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }
    public void setget()
    {
        qOneText.text = questionOne.text;
        qTwoText.text = questionTwo.text;
        
    }
}
