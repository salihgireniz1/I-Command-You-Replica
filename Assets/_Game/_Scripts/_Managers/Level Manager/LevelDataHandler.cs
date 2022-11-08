using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDataHandler : MonoBehaviour, IHandleLevelData
{
    #region Constants
    const string LEVEL = "Level";
    #endregion

    #region Properties
    public int CurrentLevel
    {
        get => currentLevel;
        private set => currentLevel = value;
    }
    #endregion
    #region Variables
    private int currentLevel;
    #endregion

    #region Methods
    public void IncreaseLevel()
    {
        // Increase the level index.
        int nextLevelIndex = CurrentLevel + 1;
        CurrentLevel = nextLevelIndex;
        SaveLevel();
    }
    public void SaveLevel()
    {
        ES3.Save(LEVEL, CurrentLevel);
    }
    public int GetCurrentLevel()
    {
        return ES3.Load(LEVEL, 1);
    }
    #endregion
}