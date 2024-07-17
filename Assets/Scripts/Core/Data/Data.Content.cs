using System;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    #region Save

    #region TeamEdit
    [Serializable]
    public class TeamEdit
    {
        public int index;
        public string charName;
        public string charNameEN;
        public string charImage;
        public int price;
        public float time;
    }

    [Serializable]
    public class TeamEditData
    {
        public List<TeamEdit> teams = new();
    }
    #endregion

    #region Character
    [Serializable]
    public class Character
    {
        public int index;
        public string charName;
        public string objName;
        public int level;
        public int hp;
        public int attack;
        public int priceIn;
        public int priceOut;
        public float time;
        public string pathImage;
    }

    [Serializable]
    public class CharacterData
    {
        public List<Character> characters = new();
    }
    #endregion

    #region Gold
    [Serializable]
    public class Gold
    {
        public int index;
        public int gold;
    }

    [Serializable]
    public class GoldData
    {
        public List<Gold> coins = new();
    }
    #endregion

    #endregion

    #region Load

    #region Word
    [Serializable]
    public class Word
    {
        public int wordIndex;
        public string buildword;
        public string attackword;
        public string skillword;
        public string fixedword;
    }

    [Serializable]
    public class WordData : ILoader<int, Word>
    {
        public List<Word> words = new();

        public Dictionary<int, Word> MakeDict()
        {
            Dictionary<int, Word> dict = new();
            foreach (Word word in words)
                dict.Add(word.wordIndex, word);
            return dict;
        }
    }
    #endregion

    #region Map
    [Serializable]
    public class Map
    {
        public int mapIndex;
        public string warName;
        public string warNameEN;
        public string warImage;
        public string warContent;
    }

    [Serializable]
    public class MapData : ILoader<int, Map>
    {
        public List<Map> maps = new();

        public Dictionary <int, Map> MakeDict()
        {
            Dictionary<int, Map> dict = new();
            foreach(Map map in maps) dict.Add(map.mapIndex, map);
            return dict;
        }
    }
    #endregion

    #region Level

    [Serializable]
    public class Level
    {
        public int level;
        public int hp;
        public int attack;
    }

    [Serializable]
    public class LevelData : ILoader<int, Level>
    {
        public List<Level> levels = new();

        public Dictionary<int, Level> MakeDict()
        {
            Dictionary<int, Level> dict = new();
            foreach (Level level in levels) dict.Add(level.level, level);
            return dict;
        }
    }

    #endregion

    #endregion
}