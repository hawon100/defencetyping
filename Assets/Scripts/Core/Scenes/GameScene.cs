using DialogueEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    private bool isConveration = true;

    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.Game;

        Managers.Typing.WordReset();
    }

    private void Update()
    {
        WaveStarter();
    }

    private void WaveStarter()
    {
        if (!isConveration) return;

        if (ConversationManager.Instance.DialoguePanel.gameObject.activeSelf) return;

        isConveration = false;
        Managers.Sound.Play("Effect/horn");
        //Managers.Sound.Play("Bgm/MEGALOVANIA", Define.Sound.Bgm);
    }

    public override void Clear()
    {

    }
}
