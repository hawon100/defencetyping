using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class CharDataEdit
{
    public Sprite charImage;
    public Button charButton;
    public GameObject charObj;
}

[CreateAssetMenu(fileName = "New CharListData", menuName = "Data/CharListData", order = int.MinValue)]
public class CharListData : BaseData
{
    public List<CharDataEdit> dataEdit = new();
}