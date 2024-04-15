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

    public void Init()
    {
        WordDict = LoadJson<WordData, int, Word>("Word/WordData").MakeDict();
    }

    Loader LoadJson<Loader, Key, Value>(string path) where Loader : ILoader<Key, Value>
    {
		TextAsset textAsset = Managers.Resource.Load<TextAsset>($"Datas/Json/{path}");
        return JsonUtility.FromJson<Loader>(textAsset.text);
	}

    //public void SaveJson<Key, Value>(Dictionary<Key, Value> data, string fileName, string path = "")
    //{
    //    // 데이터를 JSON 문자열로 직렬화
    //    string jsonString = JsonUtility.ToJson(data);

    //    // 파일 경로를 지정하고 JSON 문자열을 파일에 저장
    //    string fullPath = Path.Combine(Application.dataPath + $"/Data/{path}", $"{fileName}.json");
    //    File.WriteAllText(fullPath, jsonString);
    //}
}
