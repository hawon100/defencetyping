using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyScene : BaseScene
{
    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.Lobby;

        //PlayerPrefs.DeleteKey("TeamData");

        if (!PlayerPrefs.HasKey("CharacterData"))
        {
            Managers.DSL.SaveChar();
        }
    }

    public override void Clear()
    {

    }
}
