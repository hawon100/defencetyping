using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class CharDataStat
{
    public int level;
    public int hp;
    public int attack;
    public int time;
    public int price;
}

[System.Serializable]
public class CharDataEdit
{
    [Header("Character Setting")]
    public string charName;
    public string prefabName;
    public GameObject prefab;
    public CharDataStat stat;

    [Header("Reference")]
    public Sprite charImage;
    public Button charButton;
    public GameObject charObj;
}

[CreateAssetMenu(fileName = "New CharListData", menuName = "Data/CharListData", order = int.MinValue)]
public class CharListData : BaseData
{
    public List<CharDataEdit> dataEdit = new();
}