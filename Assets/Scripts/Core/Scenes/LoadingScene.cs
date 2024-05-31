using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScene : BaseScene
{
    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.Loading;
    }

    public override void Clear()
    {

    }
}
