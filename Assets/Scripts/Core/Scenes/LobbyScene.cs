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
        public string team1_charname;
        public string team2_charname;
        public string team3_charname;
        public string team4_charname;
    }

    public class PlayerContainer
    {
        public List<Player> teams;
    }

    private void Save()
    {
        List<Player> playerList = new List<Player>
        {
            new Player
            {
                team1_charname = "판옥선",
                team2_charname = "귀선",
                team3_charname = "방패선",
                team4_charname = "해골선",
            }
        };

        // WordsContainer 객체 생성
        PlayerContainer playerContainer = new PlayerContainer
        {
            teams = playerList
        };

        // WordsContainer 객체를 JSON 문자열로 변환
        string json = JsonConvert.SerializeObject(playerContainer, Formatting.Indented);

        // JSON 문자열을 파일로 저장
        string path = Path.Combine(Application.dataPath, "teams.json");
        File.WriteAllText(path, json);

        // 결과 확인
        //Debug.Log("JSON file created at: " + path);
        //Debug.Log("JSON content: " + json);
    }

    public override void Clear()
    {

    }
}
