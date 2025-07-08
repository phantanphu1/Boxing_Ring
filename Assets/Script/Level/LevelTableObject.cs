using System;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "LevelConfig", menuName = "Level Design/ListLevel")]
public class LevelTableObject : ScriptableObject
{
    public List<LevelTable> _lsLevelTable;
}
[Serializable]
public class LevelTable
{
    public int LevelNumber;
    public float MinDamagePlayer;
    public float MaxDamagePlayer;
    public float HealthPlayer;
    public GameMode GameMode;
    public float MinDamageEnemy;
    public float MaxDamageEnemy;
    public float HealthEnemy;
    public bool active;
}
public enum GameMode
{
    None = 0,
    OneVsOne = 1,
    OneVsMany = 2,
    ManyVsMany = 3
}
