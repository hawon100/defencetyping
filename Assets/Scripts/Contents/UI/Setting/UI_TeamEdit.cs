using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UI_TeamEdit : MonoBehaviour
{
    public RectTransform teamWin;
    public TeamData teamData;
    public HolderList holderList;

    private void Update()
    {
        for (int i = 0; i < holderList.holders.Count; i++)
        {
            if (Util.FindChild(holderList.holders[i].holderObj) == null) continue;

            holderList.holders[i].objName = Util.FindChild<Text>(Util.FindChild(holderList.holders[i].holderObj, "CharButton"), "ObjName").text;
        }
    }

    public void OnEditExit()
    {
        teamWin.DOAnchorPosX(1920, 0.5f);
    }
}
