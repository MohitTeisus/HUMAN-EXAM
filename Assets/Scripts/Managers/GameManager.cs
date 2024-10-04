using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private LevelManager[] levels;  

    public static GameManager instance;

    private string gameScene;
    private GameState currentState;
    private LevelManager currentLevel;
    private int currentLevelIndex = 0;

    public enum GameState
    {
        MainMenu,
        Breifing,
        LevelStart,
        LevelIn,
        LevelEnd,
        GameOver,
        GameEnd
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(instance);
            return;
        }
        instance = this;
    }

    private void Start()
    {
        gameScene = SceneManager.GetActiveScene().name;
        ReturnToMainMenu();
    }

    private void OnEnable()
    {
        Observer.onPause += PauseGame;    
    }

    private void OnDisable()
    {
        Observer.onPause -= PauseGame;
    }

    //Changes levels
    public void ChangeState(GameState state, LevelManager level)
    {
        currentState = state;
        currentLevel = level;

        switch (currentState)
        {
            case GameState.MainMenu:
                MainMenu(); break;  
            case GameState.Breifing:
                StartBriefing();
                break;
            case GameState.LevelStart:
                InitiateLevel();
                break;
            case GameState.LevelIn:
                RunLevel();
                break;
            case GameState.LevelEnd:
                CompleteLevel();
                break;
            case GameState.GameOver:
                GameOver();
                break;
            case GameState.GameEnd:
                GameEnd();
                break;
            default:
                break;
        }
    }

    private void MainMenu()
    {
        PlayerManager.instance.ReturnToSpawn();
        ChangeState(GameState.LevelStart, currentLevel);
    }

    private void StartBriefing()
    {
        Debug.Log("Breifing started...");

        ChangeState(GameState.LevelStart, currentLevel);
    }

    private void InitiateLevel()
    {
        Debug.Log("Level Initializing");

        currentLevel.StartLevel();
        ChangeState(GameState.LevelIn, currentLevel);
    }

    private void RunLevel()
    {
        Debug.Log("Level in " + currentLevel.gameObject.name);
    }

    private void CompleteLevel()
    {
        Debug.Log("Level end");

        //go to next level
        ChangeState(GameState.LevelStart, levels[++currentLevelIndex]);
    }

    private void GameOver()
    {
        Debug.Log("Game over, you lose!");
    }

    private void GameEnd()
    {
        Debug.Log("Game end, you win!");
    }

    private void PauseGame(bool pause)
    {
        if (pause == true)
        {
            Time.timeScale = 0.01f;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(gameScene);
    }

    public void ReturnToMainMenu()
    {
        currentLevelIndex = 0;
        ChangeState(GameState.MainMenu, levels[0]);
    }
}
