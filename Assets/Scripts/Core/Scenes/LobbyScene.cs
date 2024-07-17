using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyScene : BaseScene
{
    public Text goldText;

    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.Lobby;

        //PlayerPrefs.DeleteKey("TeamData");
        Managers.DSL.ResetCharData();
        Managers.DSL.ResetGoldData();

        if (!PlayerPrefs.HasKey("CharacterData"))
        {
            Managers.DSL.ResetCharData();
        }
        if(!PlayerPrefs.HasKey("GoldData"))
        {
            Managers.DSL.ResetGoldData();
        }
    }

    private void Update()
    {
        if (PlayerPrefs.HasKey("GoldData"))
        {
            var jsonData = PlayerPrefs.GetString("GoldData");
            Managers.DSL.goldData = JsonUtility.FromJson<Data.GoldData>(jsonData);

            goldText.text = $"{Managers.DSL.goldData.coins[0].gold}₩";
        }
    }

    public override void Clear()
    {

    }
}
