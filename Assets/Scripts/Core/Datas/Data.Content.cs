using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using static LobbyScene;

namespace Data
{
    #region Save

    #region TeamEdit
    [Serializable]
    public class Save_TeamEdit
    {
        public int index;
        public string team1_charName;
        public string team1_charImage;
        public string team2_charName;
        public string team2_charImage;
        public string team3_charName;
        public string team3_charImage;
        public string team4_charName;
        public string team4_charImage;
    }

    [Serializable]
    public class Save_TeamEditData
    {
        public List<Save_TeamEdit> teams = new();
    }
    #endregion

    #region Character
    [Serializable]
    public class Save_Character
    {
        public int index;
        public string charName;
        public string objName;
        public int level;
        public int hp;
        public int attack;
        public int price;
        public int time;
        public string pathImage;
    }

    [Serializable]
    public class Save_CharacterData
    {
        public List<Save_Character> characters = new();
    }
    #endregion

    #endregion

    #region Load

    #region Word
    [Serializable]
    public class Load_Word
    {
        public int wordIndex;
        public string buildword;
        public string attackword;
        public string skillword;
        public string fixedword;
    }

    [Serializable]
    public class Load_WordData : ILoader<int, Load_Word>
    {
        public List<Load_Word> words = new();

        public Dictionary<int, Load_Word> MakeDict()
        {
            Dictionary<int, Load_Word> dict = new();
            foreach (Load_Word word in words)
                dict.Add(word.wordIndex, word);
            return dict;
        }
    }
    #endregion

    #region TeamEdit
    [Serializable]
    public class Load_TeamEdit
    {
        public int index;
        public string team1_charName;
        public string team1_charImage;
        public string team2_charName;
        public string team2_charImage;
        public string team3_charName;
        public string team3_charImage;
        public string team4_charName;
        public string team4_charImage;
    }

    [Serializable]
    public class Load_TeamEditData : ILoader<int, Load_TeamEdit>
    {
        public List<Load_TeamEdit> teams = new();

        public Dictionary<int, Load_TeamEdit> MakeDict()
        {
            Dictionary<int, Load_TeamEdit> dict = new();
            foreach (Load_TeamEdit team in teams)
                dict.Add(team.index, team);
            return dict;
        }
    }
    #endregion

    #region Character
    [Serializable]
    public class Load_Character
    {
        public int index;
        public string charName;
        public string objName;
        public int level;
        public int hp;
        public int attack;
        public int price;
        public int time;
        public string pathImage;
    }

    [Serializable]
    public class Load_CharacterData : ILoader<int, Load_Character>
    {
        public List<Load_Character> characters = new();

        public Dictionary<int, Load_Character> MakeDict()
        {
            Dictionary<int, Load_Character> dict = new();
            foreach (Load_Character character in characters)
                dict.Add(character.index, character);
            return dict;
        }
    }
    #endregion

    #endregion
}