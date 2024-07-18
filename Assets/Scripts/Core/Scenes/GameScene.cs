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
        //Managers.Sound.Play("Effect/horn");

        //Invoke("BGMStart", 4);
        //Managers.Sound.Play("Bgm/MEGALOVANIA", Define.Sound.Bgm);
    }

    private void BGMStart()
    {
        Managers.Sound.Play("BGM/EasternMind", Define.Sound.Bgm);
    }

    public override void Clear()
    {

    }
}
