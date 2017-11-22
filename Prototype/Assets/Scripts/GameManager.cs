using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager
{
    #region Variables

    public enum stage { ONE, TWO, THREE, FOUR}
    public enum nodeNumber { ONE, TWO, THREE, FOUR}

    public Dictionary<stage, Dictionary<nodeNumber, Vector3>> NodePositions = new Dictionary<stage, Dictionary<nodeNumber, Vector3>>()
    {
        {
            stage.ONE, new Dictionary<nodeNumber, Vector3>
            {
                {nodeNumber.ONE, new Vector3(-42.2f, -19f, 0f)},
                {nodeNumber.TWO, new Vector3(-40.6f, -9.8f, 0f)},
                {nodeNumber.THREE, new Vector3(-39.3f, 1.8f, 0f)},
                {nodeNumber.FOUR, new Vector3(-39.4f, 15f, 0f)}
            }
        },
        {
            stage.TWO, new Dictionary<nodeNumber, Vector3>
            {
                {nodeNumber.ONE, new Vector3(-39.4f, 15f, 0f)},
                {nodeNumber.TWO, new Vector3(-13.8f, 9f, 0f)},
                {nodeNumber.THREE, new Vector3(-7.2f, -4.9f, 0f)},
                {nodeNumber.FOUR, new Vector3(-7.2f, -18.1f, 0f)}
            }
        },
        {
            stage.THREE, new Dictionary<nodeNumber, Vector3>
            {
                {nodeNumber.ONE, new Vector3(-7.2f, -18.1f, 0f)},
                {nodeNumber.TWO, new Vector3(16.6f, -4.9f, 0f)},
                {nodeNumber.THREE, new Vector3(26.4f, 9f, 0f)},
                {nodeNumber.FOUR, new Vector3(26.7f, 24.1f, 0f)}
            }
        },
        {
            stage.FOUR, new Dictionary<nodeNumber, Vector3>
            {
                {nodeNumber.ONE, new Vector3(26.7f, 24.1f, 0f)},
                {nodeNumber.TWO, new Vector3(47.1f, 10.4f, 0f)},
                {nodeNumber.THREE, new Vector3(54.6f,-4.9f, 0f)},
                {nodeNumber.FOUR, new Vector3(54.7f, -16.6f, 0f)}
            }
        },
    };

    public stage currentStage = stage.ONE;

    #endregion

    #region Singleton

    // create variable for storing singleton that any script can access
    private static GameManager instance;

    // create GameManager
    private GameManager()
    {

    }

    // Property for Singleton
    public static GameManager Instance
    {
        get
        {
            // If the singleton does not exist
            if (instance == null)
            {
                // create and return it
                instance = new GameManager();
            }

            // otherwise, just return it
            return instance;
        }
    }

    #endregion
}