using Data;
using System.Collections.Generic;
using UnityEngine;

public interface ILoader<Key, Value>
{
    Dictionary<Key, Value> MakeDict();
}

public class DataManager
{
    public Dictionary<int, Word> WordDict { get; private set; } = new();
    public Define.CurrentStage currentStage = Define.CurrentStage.None;

    public void Init()
    {
        for (int i = 0; i < (int)Define.CurrentStage.EndLine; i++)
        {
            if(i == (int)currentStage)
            {
                WordDict = LoadJson<WordData, int, Word>($"Word/WordData {i}").MakeDict();
            }
        }
    }

    Loader LoadJson<Loader, Key, Value>(string path) where Loader : ILoader<Key, Value>
    {
		TextAsset textAsset = Managers.Resource.Load<TextAsset>($"Datas/Json/{path}");
        return JsonUtility.FromJson<Loader>(textAsset.text);
	}
}
