using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LobbyUI : MonoBehaviour
{
    public RectTransform mapWin;
    public RectTransform levelWin;
    public RectTransform teamWin;

    public RectTransform[] door;

    public void OnButton(string btnName)
    {
        switch (btnName)
        {
            case "GameStart":
                Open();
                mapWin.DOAnchorPosY(0, 0.5f);
                break;
            case "PowerUp":
                //character Level up
                Open();
                levelWin.DOAnchorPosX(0, 0.5f);
                break;
            case "Edit":
                //character tower add or remove
                Open();
                teamWin.DOAnchorPosX(0, 0.5f);
                break;
        }
    }

    private void Open()
    {
        door[0].DOAnchorPosX(-1920, 0.5f);
        door[1].DOAnchorPosX(1920, 0.5f);
    }

    public void Close()
    {
        door[0].DOAnchorPosX(-960, 0.5f);
        door[1].DOAnchorPosX(960, 0.5f);
    }
}
