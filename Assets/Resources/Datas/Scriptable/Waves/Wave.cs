using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WaveEnemy
{
    public EnemyBase Enemy;
    public int Amount;
    public Vector2 SpawnPos;
}

[CreateAssetMenu(fileName = "New WaveData", menuName = "Data/WaveData", order = int.MinValue)]
public class Wave : ScriptableObject
{
    public List<WaveEnemy> WaveEnemie;
}
