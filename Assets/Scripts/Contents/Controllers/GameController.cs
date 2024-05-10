using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text[] text;
    public InputField typingInput;

    public List<BuildTower> towers = new();
    public BuildTower selectedTower;

    public GameObject towerSelectUI;
    public GameObject buildUI;
    public GameObject towerUI;

    public int gold;

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
    }

    private void Update()
    {
        UpdateWordTyping();
        UpdateBuild();
        UpdateType();
        UpdateWordReload();
    }

    private void UpdateType()
    {
        if (selectedTower == null) return;

        switch (selectedTower.type)
        {
            case Define.InstallTowerType.Common: maxDelayChange = 30; break;
            case Define.InstallTowerType.Rare: maxDelayChange = 20; break;
            case Define.InstallTowerType.Epic: maxDelayChange = 10; break;
            case Define.InstallTowerType.Legend: maxDelayChange = 3; break;
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

        switch (towerName)
        {
            case "Common":
                Managers.Typing.type = Define.InstallTowerType.Common;
                break;
            case "Rare":
                Managers.Typing.type = Define.InstallTowerType.Rare;
                break;
            case "Epic":
                Managers.Typing.type = Define.InstallTowerType.Epic;
                break;
            case "Legend":
                Managers.Typing.type = Define.InstallTowerType.Legend;
                break;
        }

        //price shop
        //if (gold >= 100)
        //{
        //    gold -= 100;
        //}
        //else
        //{
        //    // Don't have any Gold
        //    return;
        //}

        selectedTower.type = Managers.Typing.type;

        towerSelectUI.SetActive(false);
        buildUI.SetActive(true);

        selectedTower = null;
        Managers.Typing.tower = null;
    }

    public void OnReturnLobby()
    {
        Managers.Wave.isWave = true;
        Managers.Wave.isWin = false;
        Managers.Map.LoadScene(Define.Scene.MapSelect);
    }
}
