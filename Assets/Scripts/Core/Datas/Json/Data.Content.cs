using Data.Stats;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    [Serializable]
    public class WordData : ILoader<string, Word>
    {
        public List<Word> words = new List<Word>();

        public Dictionary<string, Word> MakeDict()
        {
            Dictionary<string, Word> dict = new Dictionary<string, Word>();
            foreach (Word word in words)
            {
                dict.Add(word.wordIndex.ToString(), word);
            }
            return dict;
        }
    }
}