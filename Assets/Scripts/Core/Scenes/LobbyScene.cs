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

        // WordsContainer 객체 생성
        PlayerContainer playerContainer = new PlayerContainer
        {
            players = playerList
        };

        // WordsContainer 객체를 JSON 문자열로 변환
        string json = JsonConvert.SerializeObject(playerContainer, Formatting.Indented);

        // JSON 문자열을 파일로 저장
        string path = Path.Combine(Application.dataPath, "stats.json");
        File.WriteAllText(path, json);

        // 결과 확인
        Debug.Log("JSON file created at: " + path);
        Debug.Log("JSON content: " + json);
    }

    public override void Clear()
    {

    }
}
