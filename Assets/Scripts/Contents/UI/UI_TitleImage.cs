using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_TitleImage : MonoBehaviour
{
    public void OnClick(string name)
    {
        switch(name)
        {
            case "Start":
                MapManager.LoadScene(Define.Scene.Lobby);
                break;
            case "Quit":
                Application.Quit();
                break;
        }
    }
}
