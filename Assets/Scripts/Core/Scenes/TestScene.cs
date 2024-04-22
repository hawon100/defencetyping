using UnityEngine;
using UnityEngine.UI;

public class TestScene : BaseScene
{
    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.TestHawon;

        Managers.Typing.WordReset();
    }

    public override void Clear()
    {

    }
}
