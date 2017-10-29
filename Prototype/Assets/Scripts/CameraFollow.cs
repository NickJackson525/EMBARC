using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject spaceship;

	// Use this for initialization
	void Start ()
    {
        spaceship = GameObject.FindGameObjectWithTag("Spaceship");
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (spaceship.GetComponent<SpaceshipMovement>().isMoving)
        {
            transform.position = new Vector3(spaceship.transform.position.x, spaceship.transform.position.y, -10f);
        }
        else
        {
            transform.position = new Vector3(spaceship.transform.position.x - 7.5f, transform.position.y, -10f);
        }
	}
}
