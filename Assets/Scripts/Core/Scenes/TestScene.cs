using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TestScene : BaseScene
{
    public List<GameObject> _towers = new();

    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.TestHawon;

        for(int i = 0; i < 16; i++)
        {
            _towers.Add(Managers.Resource.Instantiate("Tower/InstallTower"));
        }

        foreach(var tower in _towers)
        {
            Managers.Resource.Destroy(tower);
        }
    }

    public override void Clear()
    {

    }
}
