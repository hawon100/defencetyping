using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class CharDataEdit
{
    public string charName;
    public Sprite charImage;
    public GameObject charObj;
}

[CreateAssetMenu(fileName = "New CharListData", menuName = "Data/CharListData", order = int.MinValue)]
public class CharListData : BaseData
{
    public List<CharDataEdit> dataEdit = new();
}