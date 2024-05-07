using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LobbyUI : MonoBehaviour
{
    public List<RectTransform> rect = new();
    bool isGameStart = false;

    public void OnButton(string btnName)
    {
        switch(btnName)
        {
            case "GameStart":
                GameStart();
                break;
        }
    }

    private void GameStart()
    {
        isGameStart = !isGameStart;
        if (isGameStart)
        {
            rect[0].DOAnchorPosY(200, 0.5f);
            rect[1].DOAnchorPosY(320, 0.5f);
        }
        else
        {
            rect[0].DOAnchorPosY(55, 0.5f);
            rect[1].DOAnchorPosY(55, 0.5f);
        }
    }
}
