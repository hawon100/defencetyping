using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LobbyUI : MonoBehaviour
{
    public RectTransform mapWin;
    public RectTransform levelWin;
    public RectTransform teamWin;

    public void OnButton(string btnName)
    {
        switch (btnName)
        {
            case "GameStart":
                mapWin.DOAnchorPosY(0, 0.5f);
                break;
            case "PowerUp":
                //character Level up
                levelWin.DOAnchorPosX(0, 0.5f);
                break;
            case "Edit":
                //character tower add or remove
                teamWin.DOAnchorPosX(0, 0.5f);
                break;
        }
    }
}
