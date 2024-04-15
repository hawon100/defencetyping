using Data;
using System.Collections.Generic;
using UnityEngine;

public class WordManager
{
    public string BuildWord(string word)
    {
        Dictionary<int, Word> dict = Managers.Data.WordDict;
        int randWord = Random.Range(1, dict.Count + 1);
        word = dict[randWord].buildword;
        return word;
    }

    public string AttackWord(string word)
    {
        Dictionary<int, Word> dict = Managers.Data.WordDict;
        int randWord = Random.Range(1, dict.Count + 1);
        word = dict[randWord].attackword;
        return word;
    }

    public string SkillWord(string word)
    {
        Dictionary<int, Word> dict = Managers.Data.WordDict;
        int randWord = Random.Range(1, dict.Count + 1);
        word = dict[randWord].skillword;
        return word;
    }

    public string FixedWord(string word)
    {
        Dictionary<int, Word> dict = Managers.Data.WordDict;
        int randWord = Random.Range(1, dict.Count + 1);
        word = dict[randWord].fixedword;
        return word;
    }
}