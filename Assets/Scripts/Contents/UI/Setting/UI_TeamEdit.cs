using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_TeamEdit : MonoBehaviour
{
    public RectTransform teamWin;
    public HolderList holderList;

    private void Start()
    {
        for (int i = 0; i < holderList.holders.Count; i++)
        {
            holderList.holders[i].objName = Managers.Data.TeamDict[i].team1_charName;
            holderList.holders[i].holderImage.sprite = Resources.Load<Sprite>(Managers.Data.;
        }
    }

    private void Update()
    {
        for (int i = 0; i < holderList.holders.Count; i++)
        {
            if (Util.FindChild(holderList.holders[i].holderObj) == null) continue;

            holderList.holders[i].objName = Util.FindChild<Text>(Util.FindChild(holderList.holders[i].holderObj, "CharCard"), "ObjName").text;
        }
    }

    public void OnEditExit()
    {
        List<Data.Save_TeamEdit> teamList = new List<Data.Save_TeamEdit>
        { 
            new Data.Save_TeamEdit
            {
                index = 0,
                team1_charName = holderList.holders[0].objName,
                team2_charName = holderList.holders[1].objName,
                team3_charName = holderList.holders[2].objName,
                team4_charName = holderList.holders[3].objName,
            }
        };

        Data.Save_TeamEditData teamData = new Data.Save_TeamEditData
        {
            teams = teamList
        };

        Managers.Data.SaveJson("Team", "TeamData", teamData);

        teamWin.DOAnchorPosX(1920, 0.5f);
    }
}
