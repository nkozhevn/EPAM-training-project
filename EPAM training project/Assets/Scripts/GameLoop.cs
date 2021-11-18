using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop : MonoBehaviour
{
    public static GameLoop Instance{ get; private set; }
    [SerializeField] public string levelName;
    [SerializeField] public string firstLevelName;
    [SerializeField] public string nextLevelName;
    [SerializeField] private UIController uIController;
    [SerializeField] private TriggerObjects finish;
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] public List<string> itemNames;
    [SerializeField] private GameData gameData;
    [SerializeField] private Player player;
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
    public Player Player => player;

    private void Awake()
    {
        Instance = this;

        GameData.LoadGame();
    }

    private void Start()
    {
        Time.timeScale = 1f;

        if(Player != null)
        {
            Player.PlayerDied += OnPlayerDied;
        }

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
        uIController.GameOver();
    }

    public void SetDifficulty(int value)
    {
        GameData.SetGameStart(value);
        GameData.SaveGame();
    }

    private void OnFinish()
    {
        audioManager.Pause(gameThemeSoundName);
        audioManager.Play(menuThemeSoundName);
        GameData.SetLevelEnd();
        GameData.SaveGame();
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
