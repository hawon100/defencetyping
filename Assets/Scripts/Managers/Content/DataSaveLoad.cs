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
        charList = new List<Data.Save_Character>
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
            }
        };

        charData = new Data.Save_CharacterData
        {
            characters = charList
        };
    }
}