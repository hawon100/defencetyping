using System.Collections.Generic;
using UnityEngine;

public class DataSaveLoad
{
    public List<Data.Character> charList = new List<Data.Character>();
    public Data.CharacterData charData = new Data.CharacterData();
    public List<Data.TeamEdit> teamList = new List<Data.TeamEdit>();
    public Data.TeamEditData teamData = new Data.TeamEditData();
    public List<Data.Gold> goldList = new List<Data.Gold>();
    public Data.GoldData goldData = new Data.GoldData();

    public void ResetCharData()
    {
        charList = new List<Data.Character>
        {
            new Data.Character
            {
                index = 0,
                charName = "魄苛己",
                objName = "panokseon",
                level= 1,
                hp= 3,
                attack= 1,
                priceIn= 3,
                priceOut= 3,
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
                priceIn = 2,
                priceOut= 2,
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
                priceIn= 10,
                priceOut= 10,
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
                priceIn= 5,
                priceOut= 5,
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
                priceIn= 1,
                priceOut= 1,
                time= 3f,
                pathImage = "Arts/Sprites/Tower/Install/blindline"
            }
        };

        charData = new Data.CharacterData
        {
            characters = charList
        };

        string jsonData = Managers.Data.SaveJson(charData);

        PlayerPrefs.SetString("CharacterData", jsonData);
        PlayerPrefs.Save();
    }

    public void ResetGoldData()
    {
        goldList = new List<Data.Gold>
        {
            new Data.Gold
            {
                index = 0,
                gold = 0,
            }
        };

        goldData = new Data.GoldData
        {
            coins = goldList
        };

        string jsonData = Managers.Data.SaveJson(goldData);

        PlayerPrefs.SetString("GoldData", jsonData);
        PlayerPrefs.Save();
    }
}