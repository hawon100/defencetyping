using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevScene : BaseScene
{
    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.Dev;
    }

    public override void Clear()
    {

    }
}
