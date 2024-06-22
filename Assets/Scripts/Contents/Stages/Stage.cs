using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TowerBuiler
{
    public Vector2 TowerBuilderPos;

    
    public Vector2 HpPanelPos;
}

[CreateAssetMenu(fileName = "New StageData", menuName = "Data/StageData", order = int.MinValue)]
public class Stage : ScriptableObject
{
    [Header("Background")]
    public GameObject Background;

    [Header("Tower")]
    public List<TowerBuiler> Tower;

    [Header("Spawner")]
    public List<GameObject> Spawners;
    public bool isRight;
    public bool isLeft;
    public bool isTop;
    public bool isBottom;

    [Header("Wave")]
    public bool WaveLoop;
    public bool WaveRandom;
    public List<Wave> Wave;
}
