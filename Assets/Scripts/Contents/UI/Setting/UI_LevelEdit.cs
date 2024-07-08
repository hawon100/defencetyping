using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_LevelEdit : MonoBehaviour
{
    public LobbyUI lobby;
    public RectTransform levelWin;
    public RectTransform levelPanel;

    private void Start()
    {
        lobby = GetComponent<LobbyUI>();
    }

    public void OnExit()
    {
        lobby.Close();
        levelWin.DOAnchorPosX(1920, 0.5f);
        levelPanel.DOAnchorPosY(-815, 0.5f);
    }
}