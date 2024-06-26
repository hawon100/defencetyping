using Data;
using System.Collections.Generic;
using UnityEngine;

public interface ILoader<Key, Value>
{
    Dictionary<Key, Value> MakeDict();
}

public class DataManager
{
    public Dictionary<int, Load_Word> WordDict { get; private set; } = new();
    public Dictionary<int, Load_TeamEdit> TeamDict { get; private set; } = new();

    public void Init()
    {
        WordDict = LoadJson<Load_WordData, int, Load_Word>($"Word/WordData").MakeDict();
        TeamDict = LoadJson<Load_TeamEditData, int, Load_TeamEdit>($"Team/TeamData").MakeDict();
    }

    Loader LoadJson<Loader, Key, Value>(string path) where Loader : ILoader<Key, Value>
    {
		TextAsset textAsset = Managers.Resource.Load<TextAsset>($"Datas/Json/{path}");
        return JsonUtility.FromJson<Loader>(textAsset.text);
	}
}
