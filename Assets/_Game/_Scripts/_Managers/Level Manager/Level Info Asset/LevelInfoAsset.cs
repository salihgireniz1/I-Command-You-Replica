using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelInfoAsset", menuName = "Level/Level Info Asset")]
public class LevelInfoAsset : ScriptableObject
{
    public List<LevelInfo> levelInfos = new List<LevelInfo>();
}

[System.Serializable]
public struct LevelInfo
{
    public GameObject platform;
    public GameObject environment;
    public GameObject player;
}