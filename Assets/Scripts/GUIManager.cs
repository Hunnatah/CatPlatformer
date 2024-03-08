using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GUIManager : MonoBehaviour
{
    #region State Enum
    public enum State
    {
        MainMenu,
        Play,
        Pause,
        Win,
        Lose
    }
    #endregion
    #region Variables
    // State variable
    private State _gameState = State.MainMenu;
    // String array of enum names to automate length check
    private string[] _enumNames;

    #region Panel Refrences
    [SerializeField] private GameObject _PausePanel;
    [SerializeField] private GameObject _PlayPanel;
    [SerializeField] private GameObject _WinPanel;
    [SerializeField] private GameObject _LosePanel;
    #endregion

    #endregion
    #region Gamestate Switch
    private void NextState()
    {
        switch (_gameState)
        {
            case State.MainMenu:

                break; 
            case State.Play:

              break;
            case State.Win:

              break;
            case State.Lose:

              break;
            default:
                Debug.LogError("State Machine (GameState) Broke: Entered nonexistent state");
                break;
        }
    }
    #region Gamestate Functions
    //---------------TO DO-----------------
    #endregion
    #endregion
    #region Start and Update
    void Start()
    {
        // Filling enumNames array
        _enumNames = System.Enum.GetNames(typeof(State));
    }

    void Update()
    {
        
    }
    #endregion
}
