using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New StageData", menuName = "Data/StageData", order = int.MinValue)]
public class Stage : ScriptableObject
{
    public bool WaveLoop;
    public bool WaveRandom;
    public List<Wave> Wave;
}
