using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class CharDataEdit
{
    public string charName;
    public string prefabName;
    public Sprite charImage;
    public Button charButton;
    public GameObject charObj;
    public GameObject prefab;
}

[CreateAssetMenu(fileName = "New CharListData", menuName = "Data/CharListData", order = int.MinValue)]
public class CharListData : BaseData
{
    public List<CharDataEdit> dataEdit = new();
}