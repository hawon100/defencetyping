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
    public Dictionary<int, Load_TeamEdit> TeamDict { get; private set; } = new();
    public Dictionary<int, Load_Character> CharacterDict { get; private set; } = new();

    public void Init()
    {
        WordDict = LoadJson<Load_WordData, int, Load_Word>($"Word/WordData").MakeDict();
        TeamDict = LoadJson<Load_TeamEditData, int, Load_TeamEdit>($"Team/TeamData").MakeDict();
        CharacterDict = LoadJson<Load_CharacterData, int, Load_Character>($"Character/CharacterData").MakeDict();
    }

    Loader LoadJson<Loader, Key, Value>(string path) where Loader : ILoader<Key, Value>
    {
		TextAsset textAsset = Managers.Resource.Load<TextAsset>($"Datas/Json/{path}");
        return JsonUtility.FromJson<Loader>(textAsset.text);
	}

    public void SaveJson<T>(string fileName, string dataName, T container)
    {
        string json = JsonUtility.ToJson(container, true);

        string path = Path.Combine(Application.dataPath + $"/Resources/Datas/Json/{fileName}", $"{dataName}.json");
        File.WriteAllText(path, json);
    }
}
