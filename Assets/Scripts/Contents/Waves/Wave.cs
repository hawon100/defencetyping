using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Mob
{
    public GameObject Object;
    public int Count;
}

[CreateAssetMenu(fileName = "Wave")]
public class Wave : ScriptableObject
{
    public Define.WaveLevel Difficulty;
    public List<Mob> Mob;
}
