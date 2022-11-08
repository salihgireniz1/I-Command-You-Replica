using System;
using UnityEngine;

[RequireComponent(typeof(IHandleLevelInfo))]
[RequireComponent(typeof(IHandleLevelData))]
public class LevelManager : MonoBehaviour
{
    #region Events
    public static event Action<LevelInfo> OnLevelLoad; // Loader event definition.
    public static event Action OnLevelClear; // Cleaner event definition.
    #endregion

    #region Properties
    public bool IncreaseLevel // Can we go to next level?
    {
        get => increaseLevel;
        private set => increaseLevel = value;
    }
    public static LevelManager Instance { get; private set; } // Singleton.
    #endregion

    #region Variables
    IHandleLevelInfo levelInfoRespond; // Level info handler.
    IHandleLevelData levelDataRespond; // Level data handler(save, load etc.)

    [SerializeField]
    bool increaseLevel = false;
    #endregion

    #region MonoBehaviour/Initialize
    void Awake()
    {
        // Init
        if (Instance == null) Instance = this;
        else Destroy(this.gameObject);

        levelInfoRespond = GetComponent<IHandleLevelInfo>();
        levelDataRespond = GetComponent<IHandleLevelData>();
    }
    #endregion

    #region Methods

    /// <summary>
    /// Cleans the scene and loads latest level that player reached.
    /// </summary>
    public void LoadLevel()
    {
        // Initialize the processes to clear previous level from scene.
        ClearPreviousLevel();

        // Get the 'levelInfo' corresponding the index of latest level 
        // that player reached.
        LevelInfo levelInfo = CollectCurrentLevelInfoDatas();

        // Initialize new level processes.
        InitializeLevel(levelInfo);
    }

    /// <summary>
    /// Starts the initializing processes for a new level.
    /// </summary>
    public void LoadNewLevel()
    {
        // Increase the level if it is allowed.
        if (IncreaseLevel)
        {
            levelDataRespond.IncreaseLevel();
        }

        LoadLevel();
    }

    /// <summary>
    /// Reaches to responds and get current 'LevelInfo' datas.
    /// </summary>
    /// <returns>The structure that includes latest level features.</returns>
    LevelInfo CollectCurrentLevelInfoDatas()
    {
        // Get the latest level index.
        int levelIndex = levelDataRespond.GetCurrentLevel();

        // Get the 'levelInfo' corresponding the latest level index.
        LevelInfo levelInfo = levelInfoRespond.GetLevelInfo(levelIndex);

        return levelInfo;
    }


    /// <summary>
    /// Initialize a level according to the level informations.
    /// </summary>
    /// <param name="levelInfo">
    /// A structure that includes level features.
    /// </param>
    void InitializeLevel(LevelInfo levelInfo)
    {
        // Trigger the loader event with a certain info.
        OnLevelLoad?.Invoke(levelInfo);
    }

    /// <summary>
    /// Initializes the scene cleaning processes.
    /// </summary>
    void ClearPreviousLevel()
    {
        // Trigger the cleaner event.
        OnLevelClear?.Invoke();
    }
    #endregion
}