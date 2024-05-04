using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WaveTemp
{
    public EnemyBase Enemy;
    public int Count;
}

[CreateAssetMenu(fileName = "New StageData", menuName = "Data/StageData", order = int.MinValue)]
public class Stage : ScriptableObject
{
    public bool WaveLoop;
    public bool WaveRandom;
    public List<WaveTemp> Wave;
}
