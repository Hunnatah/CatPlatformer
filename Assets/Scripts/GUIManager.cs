using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

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
    [SerializeField, Tooltip("Set to the state you want to begin on")] private State _gameState;
    // String array of enum names to automate length check
    private string[] _enumNames;

    #region Panel Refrences
    [SerializeField] private GameObject _PauseMenu;
    [SerializeField] private GameObject _PlayPanel;
    [SerializeField] private GameObject _WinMenu;
    [SerializeField] private GameObject _LoseMenu;
    #endregion

    // Variable to store the flow of time
    private float _defaultTime;

    #endregion
    #region Gamestate Switch
    private void NextState()
    {
        switch (_gameState)
        {
            case State.MainMenu:
                StartCoroutine(MainMenuState());
                break; 
            case State.Play:
                StartCoroutine(PlayState());
                break;
            case State.Pause:
                StartCoroutine(PauseState());
                break;
            case State.Win:
                StartCoroutine(WinState());
                break;
            case State.Lose:
                StartCoroutine(LoseState());
                break;
            default:
                Debug.LogError("State Machine (GameState) Broke: Entered nonexistent state");
                break;
        }
    }
    #region Gamestate Functions
    private IEnumerator MainMenuState()
    {

        // Clearing any panels that may be active
        ClearPanels();

        // Ensuring game is not already in MainMenu scene
        if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName("MainMenu"))
        {
            // Swapping to MainMenu scene
            ChangeScene("MainMenu");
        }

        yield return null;
    }

    private IEnumerator PlayState()
    {
        // Clearing any panels that may be active
        ClearPanels();

        // Activating PlayPanel
        _PlayPanel.SetActive(true);

        yield return null;
    }

    private IEnumerator PauseState()
    {
        // Pausing time
        Time.timeScale = 0.0f;

        // Clearing any panels that may be active
        ClearPanels();

        // Activating PausePanel
        _PauseMenu.SetActive(true);

        yield return null;
    }

    private IEnumerator WinState()
    {
        // Pausing time
        Time.timeScale = 0.0f;

        // Clearing any panels that may be active
        ClearPanels();

        // Activating WinPanel
        _WinMenu.SetActive(true);

        yield return null;
    }

    private IEnumerator LoseState()
    {
        // Pausing time
        Time.timeScale = 0.0f;

        // Clearing any panels that may be active
        ClearPanels();

        // Activating LosePanel
        _LoseMenu.SetActive(true);

        yield return null;
    }

    public void ChangeState(string targetState)  // ----May want to swap to int-based state change----
    {
        // Setting GameState to the targeted one
        _gameState = System.Enum.Parse<State>(targetState);

        // Ensuring time isnt paused
        if (Time.timeScale != _defaultTime)
        {
            Time.timeScale = _defaultTime;
        }

        NextState();
    }
    #endregion
    #endregion
    #region General Functions
    private void ClearPanels()
    {
        // Disabling everey GUI panel
        _PauseMenu.SetActive(false);
        _PlayPanel.SetActive(false);
        _WinMenu.SetActive(false);
        _LoseMenu.SetActive(false);
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ExitToDeskTop()
    {
        // Closes the Game
        Application.Quit();

        // Does the equivilant of above in Unity editor (for testing purposes)
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
    #endregion
    #region Start
    void Start()
    {
        // Filling enumNames array
        _enumNames = System.Enum.GetNames(typeof(State));

        // Storing the flow of time
        _defaultTime = Time.timeScale;

        // Starting State Machine
        NextState();
    }
    #endregion
    #region Update
    private void Update()
    {
        // Pause Key
        if (Input.GetKeyDown(KeyCode.P))
        {
            // Differing behaviour based on active state
            if(_gameState == State.Play)
            {
                ChangeState("Pause");
            }else if (_gameState == State.Pause)
            {
                ChangeState("Play");
            }
        }

        // TEMPORARY
        if (Input.GetKeyDown(KeyCode.O) && _gameState == State.Play)
        {
            ChangeState("Win");
        }
        if (Input.GetKeyDown(KeyCode.L) && _gameState == State.Play)
        {
            ChangeState("Lose");
        }
    }
    #endregion
}
