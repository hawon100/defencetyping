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
                charName = "∆«ø¡º±",
                objName = "panokseon",
                level= 1,
                hp= 3,
                attack= 1,
                price= 5,
                time= 3f,
                pathImage= "Arts/Sprites/Ship/panokseon"
            },
            new Data.Character
            {
                index = 1,
                charName = "πÊ∆–º±",
                objName = "shieldline",
                level= 1,
                hp= 3,
                attack= 1,
                price= 5,
                time= 3f,
                pathImage= "Arts/Sprites/Ship/shieldline"
            },
            new Data.Character
            {
                index = 2,
                charName = "±Õº±",
                objName = "retrace",
                level= 1,
                hp= 3,
                attack= 1,
                price= 5,
                time= 3f,
                pathImage= "Arts/Sprites/Ship/retrace"
            },
            new Data.Character
            {
                index = 3,
                charName = "«ÿ∞Òº±",
                objName = "skullline",
                level= 1,
                hp= 3,
                attack= 1,
                price= 5,
                time= 3f,
                pathImage= "Arts/Sprites/Ship/skullline"
            },
            new Data.Character
            {
                index = 4,
                charName = "∏Õº±",
                objName = "blindline",
                level= 1,
                hp= 3,
                attack= 1,
                price= 5,
                time= 3f,
                pathImage= "Arts/Sprites/Ship/blindline"
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