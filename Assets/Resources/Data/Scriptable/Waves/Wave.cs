using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WaveEnemy
{
    public EnemyBase Enemy;
    public int Amount;
    public bool IsRandom = true;
    public Vector2 Spawn;
}

[CreateAssetMenu(fileName = "New WaveData", menuName = "Data/WaveData", order = int.MinValue)]
public class Wave : ScriptableObject
{
    public List<WaveEnemy> WaveEnemie;
    public bool BossBattle;
}
