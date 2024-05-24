using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LobbyUI : MonoBehaviour
{
    public void OnButton(string btnName)
    {
        switch (btnName)
        {
            case "GameStart":
                Managers.Map.LoadScene(Define.Scene.MapSelect);
                break;
            case "ContentWar":
                break;
        }
    }
}
