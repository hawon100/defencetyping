using Data;
using System.Collections.Generic;
using UnityEngine;
using static LobbyScene;
using System.IO;

public interface ILoader<Key, Value>
{
    Dictionary<Key, Value> MakeDict();
}

public class DataManager
{
    public Dictionary<int, Load_Word> WordDict { get; private set; } = new();

    public void Init()
    {
        WordDict = LoadJson<Load_WordData, int, Load_Word>($"Word/WordData").MakeDict();
    }

    Loader LoadJson<Loader, Key, Value>(string path) where Loader : ILoader<Key, Value>
    {
		TextAsset textAsset = Managers.Resource.Load<TextAsset>($"Datas/Json/{path}");
        return JsonUtility.FromJson<Loader>(textAsset.text);
	}

    public string SaveJson<T>(T container)
    {
        string json = JsonUtility.ToJson(container);
        return json;
    }
}
