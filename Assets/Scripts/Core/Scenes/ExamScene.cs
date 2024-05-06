using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExamScene : BaseScene
{
    public Transform target;
    public List<Wave> waveList = new();

    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.TestKangmai;

        for (int i = 0; i < waveList.Count; i++)
        {
            //Managers.Spawn.waves.Add(waveList[i]);
        }
    }

    public override void Clear()
    {

    }
}
