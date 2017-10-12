//using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// GameManager is the main managing singlton class for the application
/// </summary>
class GameManager
{
    #region Fields

    //singleton instance
    static GameManager instance;

    #endregion

    #region Constructor

    /// <summary>
    /// Private internal constructor called when the Instance
    /// property is invoked
    /// </summary>
    private GameManager()
    {
        //creates the object that calls GM's Update method. It's an
        //object that barrows Update() from a MonoBehaviour object
        //and is continuously kept saved across all Unity scenes
        Object.DontDestroyOnLoad(new GameObject("gmUpdater", typeof(Updater)));
    }

    #endregion

    #region Properties

    /// <summary>
    /// Gets the singleton instance of the GameManager
    /// </summary>
    public static GameManager Instance
    {
        get { return instance ?? (instance = new GameManager()); }
    }

    //other properties can be stored here.
    //example:

    ///// <summary>
    ///// The accessor for the player
    ///// </summary>
    //public PlayerScript Player
    //{ get; set; }

    #endregion

    #region Public Methods



    #endregion

    #region Private Methods

    private void Update()
    {
        //anything that must be updated constantly for GM goes here
        //example:
        //UIManager.Instance.Update();
    }

    #endregion

    #region Internal Updater class

    /// <summary>
    /// Internal class that updates the GameManager
    /// </summary>
    class Updater : MonoBehaviour
    {
        // Update is called once per frame
        private void Update()
        {
            Instance.Update();
        }
    }

    #endregion
}