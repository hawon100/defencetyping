using DG.Tweening;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_TeamEdit : MonoBehaviour
{
    public RectTransform teamWin;
    public HolderList holderList;
    public BackLevel backLevel;

    private LobbyUI lobby;

    private void Start()
    {
        lobby = GetComponent<LobbyUI>();
    }

    private void Update()
    {
        for (int i = 0; i < holderList.holders.Count; i++)
        {
            if (Util.FindChild(holderList.holders[i].holderObj) == null) continue;

            holderList.holders[i].objName = Util.FindChild<Text>(Util.FindChild(holderList.holders[i].holderObj, "CharCard"), "ObjName").text;
            holderList.holders[i].objNameEN = Util.FindChild<Text>(Util.FindChild(holderList.holders[i].holderObj, "CharCard"), "ObjNameEN").text;
        }
    }

    public void OnEditExit()
    {
        lobby.Close();
        backLevel._objName = "";

        Managers.DSL.teamList = new List<Data.TeamEdit>
        { 
            new Data.TeamEdit
            {
                index = 0,
                charName = holderList.holders[0].objName,
                charNameEN = holderList.holders[0].objNameEN,
                charImage = holderList.holders[0].ImagePath,
            },
            new Data.TeamEdit
            {
                index = 1,
                charName = holderList.holders[1].objName,
                charNameEN = holderList.holders[1].objNameEN,
                charImage = holderList.holders[1].ImagePath,
            },
            new Data.TeamEdit
            {
                index = 2,
                charName = holderList.holders[2].objName,
                charNameEN = holderList.holders[2].objNameEN,
                charImage = holderList.holders[2].ImagePath,
            },
            new Data.TeamEdit
            {
                index = 3,
                charName = holderList.holders[3].objName,
                charNameEN = holderList.holders[3].objNameEN,
                charImage = holderList.holders[3].ImagePath,
            },
        };

        Managers.DSL.teamData = new Data.TeamEditData
        {
            teams = Managers.DSL.teamList
        };

        string jsonData = Managers.Data.SaveJson(Managers.DSL.teamData);

        PlayerPrefs.SetString("TeamData", jsonData);
        PlayerPrefs.Save();

        teamWin.DOAnchorPosX(1920, 0.5f);
    }
}
