using Data;
using Data.Stats;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILoader<Key, Value>
{
    Dictionary<Key, Value> MakeDict();
}

public class DataManager
{
    public Dictionary<string, Word> WordDict { get; private set; } = new Dictionary<string, Word>();

    public void Init()
    {
        WordDict = LoadJson<WordData, string, Word>().MakeDict();
    }

    Loader LoadJson<Loader, Key, Value>() where Loader : ILoader<Key, Value>
    {
		//TextAsset textAsset = Managers.Resource.Load<TextAsset>($"Data/{path}");
        return JsonUtility.FromJson<Loader>(Managers.Network.UrlJson[0]);
	}   
}
