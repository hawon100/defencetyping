using System;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    #region Save

    #region TeamEdit
    [Serializable]
    public class Save_TeamEdit
    {
        public int index;
        public string charName;
        public string charNameEN;
        public string charImage;
        public int price;
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

    #endregion
}