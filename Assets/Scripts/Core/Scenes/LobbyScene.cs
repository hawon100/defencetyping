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
                team1_charname = "�ǿ���",
                team2_charname = "�ͼ�",
                team3_charname = "���м�",
                team4_charname = "�ذ�",
            }
        };

        // WordsContainer ��ü ����
        PlayerContainer playerContainer = new PlayerContainer
        {
            teams = playerList
        };

        // WordsContainer ��ü�� JSON ���ڿ��� ��ȯ
        string json = JsonConvert.SerializeObject(playerContainer, Formatting.Indented);

        // JSON ���ڿ��� ���Ϸ� ����
        string path = Path.Combine(Application.dataPath, "teams.json");
        File.WriteAllText(path, json);

        // ��� Ȯ��
        //Debug.Log("JSON file created at: " + path);
        //Debug.Log("JSON content: " + json);
    }

    public override void Clear()
    {

    }
}
