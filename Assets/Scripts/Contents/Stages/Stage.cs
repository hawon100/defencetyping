using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TowerBuiler
{
    public BuildTower TowerBuilder;
    public Vector2 TowerBuilderPos;
}

[CreateAssetMenu(fileName = "New StageData", menuName = "Data/StageData", order = int.MinValue)]
public class Stage : ScriptableObject
{
    public List<TowerBuiler> Tower;

    public bool WaveLoop;
    public bool WaveRandom;
    public List<Wave> Wave;
}
