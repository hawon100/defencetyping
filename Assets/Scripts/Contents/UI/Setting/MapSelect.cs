using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;
using Data;
using Unity.VisualScripting;

[System.Serializable]
public class MapInfomation
{
    public string warName;
    public Button warButton;
    public Sprite warImage;
    [TextArea(5, 5)] public string warContent;
}

public class MapSelect : MonoBehaviour
{
    public RectTransform mapWin;
    public GameObject spawnParent;

    private LobbyUI _lobby;
    private List<GameObject> _objList = new();

    private void Start()
    {
        _lobby = GetComponent<LobbyUI>();

        for (int i = 0; i < Managers.Data.MapDict.Count; i++) _objList.Add(Managers.Resource.Instantiate("UI/Lobby/BattleButton"));
        foreach (var obj in _objList) Managers.Resource.Destroy(obj);

        for (int i = 0; i < Managers.Data.MapDict.Count; i++)
        {
            var obj = Managers.Resource.Instantiate("UI/Lobby/BattleButton", spawnParent.transform);

            obj.name = Managers.Data.MapDict[i + 1].warNameEN;

            Util.FindChild<Text>(obj, "warName").text = Managers.Data.MapDict[i + 1].warName;
            Util.FindChild<Text>(Util.FindChild(obj, "Panel"), "warContent").text = Managers.Data.MapDict[i + 1].warContent;
            Util.FindChild<Image>(Util.FindChild(obj, "Panel"), "warImage").sprite = Resources.Load<Sprite>($"{Managers.Data.MapDict[i + 1].warImage}");

            obj.GetComponent<Button>().onClick.AddListener(() => StageSelect());
            Util.FindChild<Button>(Util.FindChild(obj, "Panel"), "warButton").onClick.AddListener(() => OnGamePlay());
        }
    }

    public void StageSelect()
    {
        Managers.Sound.Play(_lobby.buttonClick);
        string eventButtonName = EventSystem.current.currentSelectedGameObject.name;

        foreach (var obj in _objList)
        {
            if (obj.name == eventButtonName)
            {
                Managers.Game.currentStage = Resources.Load<Stage>($"Data/Scriptable/Stages/{obj.name}");
                Debug.Log(Managers.Game.currentStage);
            }
        }
    }

    public void OnGamePlay()
    {
        MapManager.LoadScene(Define.Scene.Game);
    }

    public void OnGameLobby()
    {
        _lobby.Close();
        mapWin.DOAnchorPosY(1080, 0.5f);
    }
}
