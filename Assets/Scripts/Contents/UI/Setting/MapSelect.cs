using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

[System.Serializable]
public class MapInfomation
{
    public Button warButton;
    public Sprite warImage;
    [TextArea(5, 5)] public string warContent;
}

public class MapSelect : MonoBehaviour
{
    public RectTransform mapWin;
    public RectTransform infoPanel;

    public MapInfomation[] maps;
    private MapInfomation map;

    public Image warImage;
    public Text warContent;

    public void StageSelect()
    {
        string eventButtonName = EventSystem.current.currentSelectedGameObject.name;

        for(int i = 0; i < maps.Length; i++)
        {
            if(eventButtonName == maps[i].warButton.gameObject.name)
            {
                map = maps[i];
            }
        }

        if (map == null) return;

        if (map.warButton.name == eventButtonName)
        {
            warImage.sprite = map.warImage;
            warContent.text = map.warContent;
            Managers.Game.currentStage = Resources.Load<Stage>($"Datas/Scriptable/Stages/{map.warButton.name}");
            PanelOpen();
        }
    }

    private void PanelOpen()
    {
        infoPanel.DOAnchorPosX(0, 0.5f);
    }

    public void PanelClose()
    {
        infoPanel.DOAnchorPosX(-600, 0.5f);
    }

    public void OnGamePlay()
    {
        MapManager.LoadScene(Define.Scene.Game);
    }

    public void OnGameLobby()
    {
        PanelClose();
        mapWin.DOAnchorPosY(1080, 0.5f);
    }
}
