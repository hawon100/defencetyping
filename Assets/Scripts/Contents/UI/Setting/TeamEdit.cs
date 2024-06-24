using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class TeamEdit : MonoBehaviour
{
    public RectTransform editWin;
    public GameObject content;
    public TeamData teamData;
    public CharListData charList;
    public HolderList holderList;

    private void Start()
    {
        //Temp
        return;

        for (int i = 0; i < charList.dataEdit.Count * 2; i++) holderList._charDataList.Add(Managers.Resource.Instantiate("UI/Lobby/CharButton"));
        foreach (var obj in holderList._charDataList) Managers.Resource.Destroy(obj);

        for (int i = 0; i < charList.dataEdit.Count; i++)
        {
            var obj = Managers.Resource.Instantiate("UI/Lobby/CharButton");
            charList.dataEdit[i].charObj = obj;
            charList.dataEdit[i].charObj.transform.parent = content.transform;
            charList.dataEdit[i].charObj.FindChild<Text>().text = charList.dataEdit[i].charName;
            charList.dataEdit[i].charObj.FindChild<Image>().sprite = charList.dataEdit[i].charImage;
            charList.dataEdit[i].charButton = charList.dataEdit[i].charObj.GetComponent<Button>();

            int index = i;
            charList.dataEdit[i].charButton.onClick.AddListener(() => CharAdd(index));
        }

        // Team Data Load
        for (int i = 0; i < charList.dataEdit.Count; i++)
        {
            for(int j = 0; j < teamData.team.Count; j++)
            {
                if (charList.dataEdit[i].charName == teamData.team[j].charName)
                {
                    DataLoad(i);
                }
            }
        }
    }

    private void DataLoad(int i)
    {
         int holderIndex = -1;

        for (int x = 0; x < holderList.holders.Count; x++)
        {
            if (!holderList.holders[x].isChild)
            {
                holderIndex = x;
                break;
            }
        }

        if (holderIndex == -1)
        {
            Debug.Log("No available holder");
            return;
        }

        charList.dataEdit[i].charButton.enabled = false;
        holderList.holders[holderIndex].objName = charList.dataEdit[i].charName;
        charList.dataEdit[i].charObj.transform.parent = holderList.holders[holderIndex].holderObj.transform;
        charList.dataEdit[i].charObj.transform.localScale = holderList.holders[holderIndex].holderObj.transform.localScale;
        charList.dataEdit[i].charObj.transform.position = holderList.holders[holderIndex].holderObj.transform.position;
        holderList.holders[holderIndex].isChild = true;
    }

    private void CharAdd(int i)
    {
        int holderIndex = -1;

        for (int j = 0; j < holderList.holders.Count; j++)
        {
            if (!holderList.holders[j].isChild)
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

        teamData.team[holderIndex].charName = charList.dataEdit[i].charName;
        teamData.team[holderIndex].charImage = charList.dataEdit[i].charImage;
        teamData.team[holderIndex].prefab = charList.dataEdit[i].prefab;

        charList.dataEdit[i].charButton.enabled = false;
        holderList.holders[holderIndex].objName = charList.dataEdit[i].charName;
        charList.dataEdit[i].charObj.transform.parent = holderList.holders[holderIndex].holderObj.transform;
        charList.dataEdit[i].charObj.transform.localScale = holderList.holders[holderIndex].holderObj.transform.localScale;
        charList.dataEdit[i].charObj.transform.position = holderList.holders[holderIndex].holderObj.transform.position;
        holderList.holders[holderIndex].isChild = true;
    }

    private void CharRemove(int i)
    {
        teamData.team[i].prefabName = "";
        charList.dataEdit[i].charButton.enabled = true;
        charList.dataEdit[i].charObj.transform.parent = content.transform;
        charList.dataEdit[i].charObj.transform.localScale = new Vector3(1f, 1f, 1f);
    }

    public void OnButtonClick(int index)
    {
        var obj = Util.FindChild(holderList.holders[index].holderObj);

        if (obj == null) return;

        holderList.holders[index].isChild = false; // Update the isChild state of the holder
        holderList.holders[index].objName = "";

        for (int i = index; i < holderList.holders.Count - 1; i++)
        {
            holderList.holders[i].objName = holderList.holders[i + 1].objName;
            holderList.holders[i].isChild = holderList.holders[i + 1].isChild;
            holderList.holders[i + 1].objName = "";
            holderList.holders[i + 1].isChild = false;

            // Update the teamData as well
            teamData.team[i].charName = teamData.team[i + 1].charName;
            teamData.team[i].charImage = teamData.team[i + 1].charImage;
            teamData.team[i].prefab = teamData.team[i + 1].prefab;

            teamData.team[i + 1].charName = "";
            teamData.team[i + 1].charImage = null;
            teamData.team[i + 1].prefab = null;
        }

        for (int i = 0; i < charList.dataEdit.Count; i++)
        {
            if (obj.FindChild<Text>().text == charList.dataEdit[i].charName)
            {
                CharRemove(i);
                break;
            }
        }
    }

    private void Update()
    {
        //Temp
        return;

        for (int i = 0; i < charList.dataEdit.Count; i++)
        {
            for (int j = 0; j < holderList.holders.Count; j++)
            {
                if(charList.dataEdit[i].charName == "") return;

                if (charList.dataEdit[i].charName == holderList.holders[j].objName)
                {
                    charList.dataEdit[i].charObj.transform.parent = holderList.holders[j].holderObj.transform;
                    charList.dataEdit[i].charObj.transform.position = holderList.holders[j].holderObj.transform.position;
                }
            }
        }

        for(int i = 0; i < charList.dataEdit.Count; i++)
        {
            for(int j = 0; j < teamData.team.Count; j++)
            {
                if (charList.dataEdit[i].charName == holderList.holders[j].objName)
                    teamData.team[j].prefabName = charList.dataEdit[i].prefabName;
            }
        }
    }

    public void OnEditExit()
    {
        editWin.DOAnchorPosX(17.75f, 0.5f);
    }
}
