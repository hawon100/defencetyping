using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharHolder
{
    public bool isChild;
    public GameObject holderObj;
    public string objName;
}

public class HolderList : MonoBehaviour
{
    public List<CharHolder> holders = new();
    [HideInInspector] public List<GameObject> _charDataList = new();
}