using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
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

    #region Char

    #endregion
}