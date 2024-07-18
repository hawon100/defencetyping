using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScene : BaseScene
{
    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.Title;
    }

    private void Update()
    {
        if(Input.anyKeyDown)
        {
            MapManager.LoadScene(Define.Scene.Lobby);
        }
    }

    public override void Clear()
    {

    }
}
