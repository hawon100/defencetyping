using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class LobbyScene : BaseScene
{
    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.Lobby;

        List<Data.Save_Character> characterList = new List<Data.Save_Character>
        {
            new Data.Save_Character
            {
                index = 0,
                charName = "ÆÇ¿Á¼±",
                objName = "panokseon",
                level = 1,
                hp = 3,
                attack = 1,
                price = 5,
                time = 3,
            }
        };

        Data.Save_Character save_Character = new Data.Save_Character()
        {
            index = 0,
            charName = "ÆÇ¿Á¼±",
            objName = "panokseon",
            level = 1,
            hp = 3,
            attack = 1,
            price = 5,
            time = 3,
        };

        characterList.Add(save_Character);

        Data.Save_CharacterData temp = new Data.Save_CharacterData
        {
            characters = characterList
        };

        Managers.Data.SaveJson("Temp", "TempData", temp);

        Debug.Log(Managers.Data.CharacterDict[0].charName);
    }

    public override void Clear()
    {

    }
}
