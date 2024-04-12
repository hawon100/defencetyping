using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Mob
{
    public EnemyBase Enemy;  
    public int Count;
}

[CreateAssetMenu(fileName = "Wave")]
public class Wave : ScriptableObject
{
    public List<Mob> Mob;
}
