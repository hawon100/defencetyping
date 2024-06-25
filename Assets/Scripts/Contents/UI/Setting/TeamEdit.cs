using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class TeamEdit : MonoBehaviour
{
    public RectTransform teamWin;
    public TeamData teamData;



    public void OnEditExit()
    {
        teamWin.DOAnchorPosX(1920, 0.5f);
    }
}
