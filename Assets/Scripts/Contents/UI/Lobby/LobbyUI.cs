using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LobbyUI : MonoBehaviour
{
    public RectTransform LobbyWin;

    public void OnButton(string btnName)
    {
        switch (btnName)
        {
            case "GameStart":
                LobbyWin.DOAnchorPosY(0, 0.5f);
                break;
            case "PowerUp":
                //character Level up
                break;
            case "Edit":
                //character tower add or remove
                break;
        }
    }
}
