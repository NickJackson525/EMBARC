using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipMovement : MonoBehaviour
{
    public GameObject[] jetFlames;
    public GameObject[] buttons;
    public List<GameObject> Nodes;
    public GameObject PathNode;
    public GameObject MainCamera;
    public GameObject wholeJourneyViewCamera;
    public GameObject leaderboardView;
    GameObject[] temp;
    GameObject createdNode;
    public bool isMoving = false;
    public int currNodeIndex = 1;
    public int phase = 0;
    Vector3 diff = Vector3.zero;
    float rot_z = 0;
    Quaternion beforeRotation;
    Quaternion startRotation;

    // Use this for initialization
    void Start ()
    {
        jetFlames = GameObject.FindGameObjectsWithTag("Flame");
        temp = GameObject.FindGameObjectsWithTag("Node");
        buttons = GameObject.FindGameObjectsWithTag("Button");
        startRotation = transform.rotation;

        foreach(GameObject obj in temp)
        {
            Nodes.Add(obj);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetKeyUp(KeyCode.Space))
        {
            isMoving = true;
        }

        if(Input.GetKeyUp(KeyCode.Alpha1))
        {
            MainCamera.SetActive(true);
            wholeJourneyViewCamera.SetActive(false);
            leaderboardView.SetActive(false);
        }

        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            MainCamera.SetActive(false);
            wholeJourneyViewCamera.SetActive(true);
            leaderboardView.SetActive(false);
        }

        if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            MainCamera.SetActive(false);
            wholeJourneyViewCamera.SetActive(false);
            leaderboardView.SetActive(true);
        }

        if (isMoving && !jetFlames[0].activeSelf)
        {
            foreach(GameObject obj in jetFlames)
            {
                obj.SetActive(true);
            }
        }
        else if (!isMoving && jetFlames[0].activeSelf)
        {
            foreach (GameObject obj in jetFlames)
            {
                obj.SetActive(false);
            }
        }

        if (isMoving && Nodes.Count > 0)
        {
            foreach(GameObject obj in Nodes)
            {
                if (obj != null)
                {
                    if (obj.name == "PathNode" + currNodeIndex)
                    {
                        transform.position = Vector3.MoveTowards(transform.position, obj.transform.position, .2f);
                        beforeRotation = transform.rotation;

                        diff = obj.transform.position - transform.position;
                        diff.Normalize();
                        rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
                        beforeRotation = Quaternion.Euler(0f, 0f, rot_z - 90);
                        transform.rotation = Quaternion.Lerp(transform.rotation, beforeRotation, .1f);

                        if (Vector3.Distance(transform.position, obj.transform.position) < .1f)
                        {
                            transform.position = obj.transform.position;
                            currNodeIndex++;

                            if (currNodeIndex > Nodes.Count)
                            {
                                isMoving = false;
                                phase++;
                                currNodeIndex = 1;

                                foreach (GameObject button in buttons)
                                {
                                    button.SetActive(true);
                                }
                            }
                        }
                    }
                }
            }
        }
        else
        {
            isMoving = false;
            transform.rotation = Quaternion.Lerp(transform.rotation, startRotation, .1f);

            foreach (GameObject button in buttons)
            {
                button.SetActive(true);
            }
        }
    }

    public void NextStage()
    {
        if (Nodes.Count > 0)
        {
            Nodes.RemoveAt(0);
            Nodes.RemoveAt(0);
            Nodes.RemoveAt(0);
            Nodes.RemoveAt(0);
            Nodes.Clear();
        }

        createdNode = Instantiate(PathNode, GameManager.Instance.NodePositions[GameManager.Instance.currentStage][GameManager.nodeNumber.ONE], transform.rotation);
        createdNode.name = "PathNode1";
        Nodes.Add(createdNode);
        createdNode = Instantiate(PathNode, GameManager.Instance.NodePositions[GameManager.Instance.currentStage][GameManager.nodeNumber.TWO], transform.rotation);
        createdNode.name = "PathNode2";
        Nodes.Add(createdNode);
        createdNode = Instantiate(PathNode, GameManager.Instance.NodePositions[GameManager.Instance.currentStage][GameManager.nodeNumber.THREE], transform.rotation);
        createdNode.name = "PathNode3";
        Nodes.Add(createdNode);
        createdNode = Instantiate(PathNode, GameManager.Instance.NodePositions[GameManager.Instance.currentStage][GameManager.nodeNumber.FOUR], transform.rotation);
        createdNode.name = "PathNode4";
        Nodes.Add(createdNode);

        switch (GameManager.Instance.currentStage)
        {
            case GameManager.stage.ONE:
                GameManager.Instance.currentStage = GameManager.stage.TWO;
                break;
            case GameManager.stage.TWO:
                GameManager.Instance.currentStage = GameManager.stage.THREE;
                break;
            case GameManager.stage.THREE:
                GameManager.Instance.currentStage = GameManager.stage.FOUR;
                break;
            default:
                break;
        }
    }
}
