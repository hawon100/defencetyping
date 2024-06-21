using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class CharDataEdit
{
    public string charName;
    public Sprite charImage;
    public Button charButton;
    public GameObject charObj;
    public GameObject prefab;
}

[System.Serializable]
public class CharHolder
{
    public bool isChild;
    public GameObject holderObj;
    public string objName;
}

public class TeamEdit : MonoBehaviour
{
    public GameObject content;
    public List<CharDataEdit> dataEdit = new();
    public List<CharHolder> holders = new();
    List<GameObject> _charDataList = new();
    public int currentIndex = 0;
    public TeamData teamData;

    private void Start()
    {
        for (int i = 0; i < dataEdit.Count * 2; i++) _charDataList.Add(Managers.Resource.Instantiate("UI/Lobby/CharButton"));
        foreach (var obj in _charDataList) Managers.Resource.Destroy(obj);

        for (int i = 0; i < dataEdit.Count; i++)
        {
            var obj = Managers.Resource.Instantiate("UI/Lobby/CharButton");
            dataEdit[i].charObj = obj;
            dataEdit[i].charObj.transform.parent = content.transform;
            dataEdit[i].charObj.FindChild<Text>().text = dataEdit[i].charName;
            dataEdit[i].charObj.FindChild<Image>().sprite = dataEdit[i].charImage;
            dataEdit[i].charButton = dataEdit[i].charObj.GetComponent<Button>();

            int index = i;
            dataEdit[i].charButton.onClick.AddListener(() => CharAdd(index));

        }

        // Team Data Load
        for (int i = 0; i < dataEdit.Count; i++)
        {
            DataLoad(i);

            // if (dataEdit[i].charName == teamData.team[i].charName)
            // {
            // }
        }
    }

    private void DataLoad(int i)
    {
        Debug.Log($"{teamData.team[i].charName}");


        int holderIndex = -1;

        for (int j = 0; j < holders.Count; j++)
        {
            if (!holders[j].isChild)
            {
                holderIndex = j;
                break;
            }
        }

        if (holderIndex == -1)
        {
            Debug.Log("No available holder");
            return;
        }

        if (teamData.team[i].charName == "") return;

        dataEdit[i].charButton.enabled = false;
        holders[holderIndex].objName = dataEdit[i].charName;
        dataEdit[i].charObj.transform.parent = holders[holderIndex].holderObj.transform;
        dataEdit[i].charObj.transform.localScale = holders[holderIndex].holderObj.transform.localScale;
        dataEdit[i].charObj.transform.position = holders[holderIndex].holderObj.transform.position;
        holders[holderIndex].isChild = true;
        currentIndex++;
    }

    private void CharAdd(int i)
    {
        int holderIndex = -1;

        for (int j = 0; j < holders.Count; j++)
        {
            if (!holders[j].isChild)
            {
                holderIndex = j;
                break;
            }
        }

        if (holderIndex == -1)
        {
            Debug.Log("No available holder");
            return;
        }

        teamData.team[holderIndex].charName = dataEdit[i].charName;
        teamData.team[holderIndex].charImage = dataEdit[i].charImage;
        teamData.team[holderIndex].prefab = dataEdit[i].prefab;

        dataEdit[i].charButton.enabled = false;
        holders[holderIndex].objName = dataEdit[i].charName;
        dataEdit[i].charObj.transform.parent = holders[holderIndex].holderObj.transform;
        dataEdit[i].charObj.transform.localScale = holders[holderIndex].holderObj.transform.localScale;
        dataEdit[i].charObj.transform.position = holders[holderIndex].holderObj.transform.position;
        holders[holderIndex].isChild = true;
        currentIndex++;
    }

    private void CharRemove(int i)
    {
        dataEdit[i].charButton.enabled = true;
        dataEdit[i].charObj.transform.parent = content.transform;
        dataEdit[i].charObj.transform.localScale = new Vector3(1f, 1f, 1f);
        currentIndex--;
    }

    private void Swap<T>(ref T x, ref T y)
    {
        T temp = x;
        x = y;
        y = temp;
    }

    public void OnButtonClick(int index)
    {
        var obj = Util.FindChild(holders[index].holderObj);
        Debug.Log(obj);

        if (obj == null) return;

        holders[index].isChild = false; // Update the isChild state of the holder
        holders[index].objName = "";

        for (int i = 0; i < dataEdit.Count; i++)
        {
            if (obj.FindChild<Text>().text == dataEdit[i].charName)
            {
                teamData.team[index].charName = "";
                teamData.team[index].charImage = null;
                teamData.team[index].prefab = null;
                CharRemove(i);
            }
        }
    }
}
