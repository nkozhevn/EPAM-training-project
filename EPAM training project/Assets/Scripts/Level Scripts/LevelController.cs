using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public event Action GameInitialized;
    public event Action LevelEnded;
    public static LevelController Instance{ get; private set; }
    [SerializeField] private UIController uIController;
    [SerializeField] private TriggerObjects finish;
    //[SerializeField] public List<string> itemNames;
    [SerializeField] private GameData gameData;
    [SerializeField] private GameObject cameraPrefab;
    [SerializeField] private GameObject playerPrefab;
    //[SerializeField] private Player player;
    [SerializeField] private AudioManager audioManager;

    [HideInInspector] public bool gameIsPaused = false;
    [HideInInspector] public bool objective = false;

    public GameData GameData
    {
        get
        {
            return gameData;
        }
        private set
        {
            gameData = value;
        }
    }
    public Player Player { get; private set; }
    public UIController UIController => uIController;

    private void Awake()
    {
        Instance = this;

        GameData.LoadGame();

        if(SceneManager.GetActiveScene().name != GameData.MainMenuSceneName)
        {
            GameObject cam = Instantiate(cameraPrefab);
            Player = Instantiate(playerPrefab).GetComponent<Player>();
            Player.PlayerDied += OnPlayerDied;
        }
    }

    private void Start()
    {
        Time.timeScale = 1f;

        if(Player != null)
        {
            Player.PlayerDied += OnPlayerDied;
        }

        audioManager.Play(GameData.GameThemeSoundName);

        GameInitialized?.Invoke();
    }

    private void Update()
    {
        if(finish != null)
        {
            if(finish.IsActivated && objective)
            {
                OnFinish();
            }
        }
    }

    private void OnPlayerDied()
    {
        audioManager.Pause(GameData.GameThemeSoundName);
        audioManager.Play(GameData.MenuThemeSoundName);
        GameData.SetGameEnd(GameData.FirstLevelName);
        GameData.SaveGame();
        uIController.GameOver();
        LevelEnded?.Invoke();
    }

    public void SetDifficulty(int value)
    {
        GameData.SetGameStart(value, "Pistol");
        GameData.SaveGame();
    }

    private void OnFinish()
    {
        audioManager.Pause(GameData.GameThemeSoundName);
        audioManager.Play(GameData.MenuThemeSoundName);
        GameData.SetLevelEnd();
        GameData.SaveGame();
        LevelEnded?.Invoke();
        uIController.Finish();
    }

    private void OnDestroy()
    {
        if(Player != null)
        {
            Player.PlayerDied -= OnPlayerDied;
        }
    }
}
