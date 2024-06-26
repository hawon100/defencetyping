using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_LevelEdit : MonoBehaviour
{
    public RectTransform levelWin;
    public CharListData charList;



    public void OnExit()
    {
        levelWin.DOAnchorPosX(1920, 0.5f);
    }
}