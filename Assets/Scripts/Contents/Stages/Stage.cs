using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New StageData", menuName = "Data/StageData", order = int.MinValue)]
public class Stage : ScriptableObject
{
    [Header("Background")]
    public GameObject Background;

    [Header("Camera")]
    public float mapMinX = -30f;
    public float mapMaxX = 30f;
    public float mapMinY = -10f;
    public float mapMaxY = 10f;

    [Header("Tower")]
    public List<Vector2> TowerBuilderPos;

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
