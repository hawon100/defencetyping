using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharData
{
    public string charName;
    public Sprite charImage;
    public GameObject prefab;
}

[CreateAssetMenu(fileName = "New TeamData", menuName = "Data/TeamData", order = int.MinValue)]
public class TeamData : BaseData
{
    public List<CharData> team = new List<CharData>();
}
