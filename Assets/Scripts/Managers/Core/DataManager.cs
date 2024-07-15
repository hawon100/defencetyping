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
    public Dictionary<int, Map> MapDict { get; private set; } = new();
    public Dictionary<int, Level> LevelDict { get; private set; } = new();

    public void Init()
    {
        WordDict = LoadJson<WordData, int, Word>("WordData").MakeDict();
        MapDict = LoadJson<MapData, int, Map>("MapData").MakeDict();
        LevelDict = LoadJson<LevelData, int, Level>("LevelData").MakeDict();
    }

    Loader LoadJson<Loader, Key, Value>(string path) where Loader : ILoader<Key, Value>
    {
		TextAsset textAsset = Managers.Resource.Load<TextAsset>($"Data/JsonData/{path}");
        return JsonUtility.FromJson<Loader>(textAsset.text);
	}

    public string SaveJson<T>(T container)
    {
        return JsonUtility.ToJson(container);
    }
}
