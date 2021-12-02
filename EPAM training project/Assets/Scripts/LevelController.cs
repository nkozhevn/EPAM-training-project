using System;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public Action GameInitialized;

    public static LevelController Instance { get; private set; }
    
    //TODO: not Monobeh
    [SerializeField] private GameData gameData;

    [Header("Objects To Instantiate")]
    [SerializeField] private Player playerPrefab;
    


    [Header("Sub Systems")]
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private UIController uIController;


    
    
    
    [Header("Object To Remove")]
    [SerializeField] public string levelName;
    [SerializeField] public string firstLevelName;
    [SerializeField] public string nextLevelName;
    [SerializeField] private TriggerObjects finish;
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
    public bool IsInitialized { get; private set; }



    private void Awake()
    {
        Instance = this;
        IsInitialized = false;

        GameData.LoadGame();
        SpawnPlayer();

        IsInitialized = true;
        GameInitialized?.Invoke();
    }

    private void Start()
    {
        audioManager.Play(gameThemeSoundName);
    }

    private void SpawnPlayer()
    {
        Player = Instantiate(playerPrefab);
        Player.PlayerDied += OnPlayerDied;
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
        GameData.SetGameStart(value, "Pistol");
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
