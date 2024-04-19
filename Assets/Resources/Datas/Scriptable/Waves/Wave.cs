using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Mob
{
    public EnemyBase Enemy;  
    public int Count;
}

[CreateAssetMenu(fileName = "New WaveData", menuName = "Data/WaveData", order = int.MinValue)]
public class Wave : ScriptableObject
{
    public List<Mob> Mob;
}
