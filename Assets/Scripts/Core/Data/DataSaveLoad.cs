using System.Collections.Generic;
using UnityEngine;

public class DataSaveLoad
{
    public List<Data.Character> charList = new List<Data.Character>();
    public Data.CharacterData charData = new Data.CharacterData();
    public List<Data.TeamEdit> teamList = new List<Data.TeamEdit>();
    public Data.TeamEditData teamData = new Data.TeamEditData();

    public void SaveChar()
    {
        Managers.DSL.charList = new List<Data.Character>
        {
            new Data.Character
            {
                index = 0,
                charName = "魄苛己",
                objName = "panokseon",
                level= 1,
                hp= 3,
                attack= 1,
                price= 5,
                time= 3f,
                pathImage= "Arts/Sprites/Tower/Install/panokseon"
            },
            new Data.Character
            {
                index = 1,
                charName = "规菩己",
                objName = "shieldline",
                level= 1,
                hp= 3,
                attack= 1,
                price= 5,
                time= 3f,
                pathImage= "Arts/Sprites/Tower/Install/shieldline"
            },
            new Data.Character
            {
                index = 2,
                charName = "芭合己",
                objName = "retrace",
                level= 1,
                hp= 3,
                attack= 1,
                price= 5,
                time= 3f,
                pathImage= "Arts/Sprites/Tower/Install/retrace"
            },
            new Data.Character
            {
                index = 3,
                charName = "秦榜己",
                objName = "skullline",
                level= 1,
                hp= 3,
                attack= 1,
                price= 5,
                time= 3f,
                pathImage= "Arts/Sprites/Tower/Install/skullline"
            },
            new Data.Character
            {
                index = 4,
                charName = "竿己",
                objName = "blindline",
                level= 1,
                hp= 3,
                attack= 1,
                price= 5,
                time= 3f,
                pathImage= "Arts/Sprites/Tower/Install/blindline"
            }
        };

        Managers.DSL.charData = new Data.CharacterData
        {
            characters = Managers.DSL.charList
        };

        string jsonData = Managers.Data.SaveJson(Managers.DSL.charData);

        PlayerPrefs.SetString("CharacterData", jsonData);
        PlayerPrefs.Save();
    }
}