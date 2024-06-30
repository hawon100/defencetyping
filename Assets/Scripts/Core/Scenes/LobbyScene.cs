using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class LobbyScene : BaseScene
{
    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.Lobby;
    }

    public override void Clear()
    {

    }
}
