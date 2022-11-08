using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleLevelInfos : MonoBehaviour, IHandleLevelInfo
{
    #region Properties
    public LevelInfoAsset LevelInfoAsset
    {
        get => levelInfoAsset;
    }
    #endregion

    #region Variables
    [SerializeField] LevelInfoAsset levelInfoAsset;
    #endregion

    #region Methods
    public LevelInfo GetLevelInfo(int levelIndex)
    {
        // Member of the 'levelInfos' list will be one minus of the levelIndex.
        int infoIndex = levelIndex - 1;
        if (levelInfoAsset == null)
        {
            throw new System.Exception($"Please insert a 'LevelInfoAsset' scriptable object to {this} class!");
        }
        else
        {
            if (levelInfoAsset.levelInfos.Count == 0)
            {
                throw new System.Exception($"The 'LevelInfos' list in {levelInfoAsset} is empty! Add at least one member to the list!");
            }
            return LevelInfoAsset.levelInfos[infoIndex];
        }
    }
    #endregion
}