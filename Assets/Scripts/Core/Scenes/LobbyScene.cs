using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class LobbyScene : BaseScene
{
    protected override void Init()
    {
        base.Init();
        
        SceneType = Define.Scene.Lobby;

        Save();
    }

    public class Player
    {
        public string name;
        public int score;
    }

    public class PlayerContainer
    {
        public List<Player> players;
    }

    private void Save()
    {
        List<Player> playerList = new List<Player>
        {
            new Player
            {
                name = "1",
                score = 10,
            },
            new Player
            {
                name = "2",
                score = 30,
            }
        };

        // WordsContainer ��ü ����
        PlayerContainer playerContainer = new PlayerContainer
        {
            players = playerList
        };

        // WordsContainer ��ü�� JSON ���ڿ��� ��ȯ
        string json = JsonConvert.SerializeObject(playerContainer, Formatting.Indented);

        // JSON ���ڿ��� ���Ϸ� ����
        string path = Path.Combine(Application.dataPath, "stats.json");
        File.WriteAllText(path, json);

        // ��� Ȯ��
        Debug.Log("JSON file created at: " + path);
        Debug.Log("JSON content: " + json);
    }

    public override void Clear()
    {

    }
}
