using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyScene : BaseScene
{
    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.Lobby;

        //Managers.DSL.charList[0].level = 1;

        //string jsonData = Managers.Data.SaveJson(teamData);

        //PlayerPrefs.SetString("CharacterData", jsonData);
        //PlayerPrefs.Save();
        //Debug.Log(PlayerPrefs.GetString("CharacterData"));
    }

    public override void Clear()
    {

    }
}
