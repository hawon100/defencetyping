using System.Collections.Generic;
using UnityEngine;

public class DataSaveLoad
{
    public List<Data.Save_Character> charList = new List<Data.Save_Character>();
    public Data.Save_CharacterData charData = new Data.Save_CharacterData();
    public List<Data.Save_TeamEdit> teamList = new List<Data.Save_TeamEdit>();
    public Data.Save_TeamEditData teamData = new Data.Save_TeamEditData();

    public void SaveChar()
    {
        Managers.DSL.charList = new List<Data.Save_Character>
        {
            new Data.Save_Character
            {
                index = 0,
                charName = "∆«ø¡º±",
                objName = "panokseon",
                level= 1,
                hp= 3,
                attack= 1,
                price= 5,
                time= 3,
                pathImage= "Assets/Sprites/Ship/panokseon"
            },
            new Data.Save_Character
            {
                index = 1,
                charName = "πÊ∆–º±",
                objName = "shieldline",
                level= 1,
                hp= 3,
                attack= 1,
                price= 5,
                time= 3,
                pathImage= "Assets/Sprites/Ship/shieldline"
            },
            new Data.Save_Character
            {
                index = 2,
                charName = "±Õº±",
                objName = "retrace",
                level= 1,
                hp= 3,
                attack= 1,
                price= 5,
                time= 3,
                pathImage= "Assets/Sprites/Ship/retrace"
            },
            new Data.Save_Character
            {
                index = 3,
                charName = "«ÿ∞Òº±",
                objName = "skullline",
                level= 1,
                hp= 3,
                attack= 1,
                price= 5,
                time= 3,
                pathImage= "Assets/Sprites/Ship/skullline"
            },
            new Data.Save_Character
            {
                index = 4,
                charName = "∏Õº±",
                objName = "blindline",
                level= 1,
                hp= 3,
                attack= 1,
                price= 5,
                time= 3,
                pathImage= "Assets/Sprites/Ship/blindline"
            }
        };

        Managers.DSL.charData = new Data.Save_CharacterData
        {
            characters = Managers.DSL.charList
        };

        string jsonData = Managers.Data.SaveJson(Managers.DSL.charData);

        PlayerPrefs.SetString("CharacterData", jsonData);
        PlayerPrefs.Save();
    }
}