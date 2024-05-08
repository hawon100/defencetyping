using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LobbyUI : MonoBehaviour
{
    public List<RectTransform> rect = new();

    public void OnButton(string btnName)
    {
        switch(btnName)
        {
            case "GameStart":
                GameOpen();
                break;
            case "Background":
                GameClose();
                break;
        }
    }

    private void GameOpen()
    {
        rect[0].DOAnchorPosY(200, 0.5f);
        rect[1].DOAnchorPosY(320, 0.5f);
    }

    private void GameClose()
    {
        rect[0].DOAnchorPosY(55, 0.5f);
        rect[1].DOAnchorPosY(55, 0.5f);
    }
}
