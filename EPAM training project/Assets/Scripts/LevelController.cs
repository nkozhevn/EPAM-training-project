using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelController : MonoBehaviour
{
    public event Action GameInitialized;
    public event Action LevelEnded;
    public static LevelController Instance{ get; private set; }
    [SerializeField] public string levelName;
    [SerializeField] public string firstLevelName;
    [SerializeField] public string nextLevelName;
    [SerializeField] private UIController uIController;
    [SerializeField] private TriggerObjects finish;
    //[SerializeField] public List<string> itemNames;
    [SerializeField] private GameData gameData;
    [SerializeField] private GameObject cameraPrefab;
    [SerializeField] private GameObject playerPrefab;
    //[SerializeField] private Player player;
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private string gameThemeSoundName;
    [SerializeField] private string menuThemeSoundName;

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

        GameObject cam = Instantiate(cameraPrefab);
        Player = Instantiate(playerPrefab).GetComponent<Player>();
        Player.PlayerDied += OnPlayerDied;
    }

    private void Start()
    {
        Time.timeScale = 1f;

        if(Player != null)
        {
            Player.PlayerDied += OnPlayerDied;
        }

        GameInitialized?.Invoke();

        audioManager.Play(gameThemeSoundName);
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
        audioManager.Pause(gameThemeSoundName);
        audioManager.Play(menuThemeSoundName);
        GameData.SetGameEnd(firstLevelName);
        GameData.SaveGame();
        LevelEnded?.Invoke();
        uIController.GameOver();
    }

    public void SetDifficulty(int value)
    {
        GameData.SetGameStart(value, "Pistol");
        GameData.SaveGame();
    }

    private void OnFinish()
    {
        audioManager.Pause(gameThemeSoundName);
        audioManager.Play(menuThemeSoundName);
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
