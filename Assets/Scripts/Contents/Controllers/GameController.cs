using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text[] text;
    public Text[] captaintext;
    public InputField typingInput;

    public List<BuildTower> towers = new();
    public BuildTower selectedTower;

    public GameObject towerSelectUI;
    public GameObject buildUI;
    public GameObject towerUI;
    public GameObject captainUI;

    public Text goldText;
    public Text[] towerNameText = new Text[4];
    public Text[] towerPriceText = new Text[4];
    public int price;

    public Text warningText;

    public float curDelayChange;
    public float maxDelayChange;

    public Slider[] wordResetTimer;

    public Vector3 towerOffset;

    public Transform target;
    public Transform background;

    private void Start()
    {
        Managers.Game.target = target;
        Managers.Game.background = background;
        typingInput.ActivateInputField();

        string jsonData = PlayerPrefs.GetString("TeamData");
        Managers.DSL.teamData = JsonUtility.FromJson<Data.TeamEditData>(jsonData);

        for (int i = 0; i < Managers.DSL.teamData.teams.Count; i++)
        {
            towerNameText[i].text = $"{Managers.DSL.teamData.teams[i].charName}";
            towerPriceText[i].text = $"{Managers.DSL.teamData.teams[i].price}$";
        }
    }

    private void Update()
    {
        goldText.text = $"{UserStat.Gold}$";

        UpdateWordTyping();
        UpdateBuild();
        UpdateType();
        UpdateWordReload();
    }

    private void UpdateType()
    {
        if (selectedTower == null) return;

        string jsonData = PlayerPrefs.GetString("TeamData");
        Managers.DSL.teamData = JsonUtility.FromJson<Data.TeamEditData>(jsonData);

        switch (selectedTower.type)
        {
            case Define.InstallTowerType.Common: maxDelayChange = Managers.DSL.teamData.teams[0].time; break;
            case Define.InstallTowerType.Rare: maxDelayChange = Managers.DSL.teamData.teams[1].time; break;
            case Define.InstallTowerType.Epic: maxDelayChange = Managers.DSL.teamData.teams[2].time; break;
            case Define.InstallTowerType.Legend: maxDelayChange = Managers.DSL.teamData.teams[3].time; break;
        }

        if (!selectedTower.isTyping)
        {
            selectedTower = null;
        }
    }

    private void UpdateWordTyping()
    {
        for (int i = 0; i < text.Length; i++)
        {
            text[i].text = Managers.Typing._word[i];
        }

        for (int i = 0; i < captaintext.Length; i++)
        {
            captaintext[i].text = Managers.Typing._word[i];
        }

        Managers.Typing._input = typingInput.text;

        typingInput.text = Managers.Typing.WordEnter(typingInput.text);

        foreach (var tower in towers)
        {
            if (tower.isTyping)
            {
                selectedTower = tower;
                break;
            }
        }
    }

    private void UpdateBuild()
    {
        if (Managers.Typing.tower == null || selectedTower == null) return;

        Managers.Typing.tower.transform.parent = selectedTower.transform;
        Managers.Typing.tower.transform.position = selectedTower.transform.position;

        if (!selectedTower.isTyping)
        {
            selectedTower = null;
            //Managers.Typing.tower = null;
        }
    }

    private void UpdateWordReload()
    {
        if (!towerUI.activeSelf && !buildUI.activeSelf)
        {
            curDelayChange = 0;
            return;
        }

        foreach (var timer in wordResetTimer)
        {
            timer.value = curDelayChange / maxDelayChange;
        }

        curDelayChange += Time.deltaTime;

        if (curDelayChange >= maxDelayChange)
        {
            Managers.Typing.WordReset();
            curDelayChange = 0;
        }
    }

    public void BuildTowerSelect(string towerName)
    {
        if (selectedTower == null) return;

        string jsonTeamData = PlayerPrefs.GetString("TeamData");
        Managers.DSL.teamData = JsonUtility.FromJson<Data.TeamEditData>(jsonTeamData);

        switch (towerName)
        {
            case "Common":
                Managers.Typing.type = Define.InstallTowerType.Common;
                price = Managers.DSL.teamData.teams[0].price;
                break;
            case "Rare":
                Managers.Typing.type = Define.InstallTowerType.Rare;
                price = Managers.DSL.teamData.teams[1].price;
                break;
            case "Epic":
                Managers.Typing.type = Define.InstallTowerType.Epic;
                price = Managers.DSL.teamData.teams[2].price;
                break;
            case "Legend":
                Managers.Typing.type = Define.InstallTowerType.Legend;
                price = Managers.DSL.teamData.teams[3].price;
                break;
        }

        //price shop
        if (UserStat.Gold >= price)
        {
            UserStat.Gold -= price;
        }
        else
        {
            // don't have any gold

            return;
        }

        selectedTower.type = Managers.Typing.type;

        towerSelectUI.SetActive(false);
        buildUI.SetActive(true);

        selectedTower = null;
        //Temp
        //Managers.Typing.tower = null;
    }

    public void OnReturnLobby()
    {
        Managers.Wave.isWave = true;
        Managers.Wave.isWin = false;
        MapManager.LoadScene(Define.Scene.Lobby);
    }
}
