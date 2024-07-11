using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    public AudioClip horn;

    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.Game;

        Managers.Typing.WordReset();

        Managers.Sound.Play(horn);
    }

    public override void Clear()
    {

    }
}
