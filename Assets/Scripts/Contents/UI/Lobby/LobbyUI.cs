using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LobbyUI : MonoBehaviour
{
    public List<RectTransform> rect = new();
    public RectTransform towerPanel;

    int _mask = (1 << (int)Define.Layer.Background) | (1 << (int)Define.Layer.TowerInstall) | (1 << (int)Define.Layer.Tower);

    private void Start()
    {
        Managers.Input.MouseAction -= OnMouseEvent;
        Managers.Input.MouseAction += OnMouseEvent;
    }

    private void OnMouseEvent(Define.MouseEvent evt)
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 rayOrigin = new Vector2(mousePosition.x, mousePosition.y);
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.zero, 100.0f, _mask);
        Debug.DrawRay(rayOrigin, Vector2.zero * 100.0f, Color.red, 1.0f);

        Debug.Log(hit.collider);

        if (hit.collider == null) return;

        Debug.Log(hit.collider.gameObject);
        
        switch(hit.collider.gameObject.layer)
        {
            case (int)Define.Layer.Background:
                OnMouseEvent_PanelClose(evt);
                break;
            case (int)Define.Layer.Tower:
                OnMouseEvent_PanelOpen(evt);
                break;
        }
    }

    private void OnMouseEvent_PanelOpen(Define.MouseEvent evt)
    {
        if (evt == Define.MouseEvent.PointerDown)
        {
            towerPanel.DOAnchorPosX(0, 0.5f);
            GameClose();
        }
    }

    private void OnMouseEvent_PanelClose(Define.MouseEvent evt)
    {
        if (evt == Define.MouseEvent.PointerDown)
        {
            towerPanel.DOAnchorPosX(-600, 0.5f);
            GameClose();
        }
    }

    public void OnButton(string btnName)
    {
        switch (btnName)
        {
            case "GameStart":
                GameOpen();
                break;
            case "HistoryWar":
                Managers.Map.LoadScene(Define.Scene.MapSelect);
                break;
            case "ContentWar":
                break;
        }
    }

    private void GameOpen()
    {
        rect[0].DOAnchorPosY(200, 0.5f);
        rect[1].DOAnchorPosY(320, 0.5f);
    }

    private void GameClose()
    {
        rect[0].DOAnchorPosY(55, 0.5f);
        rect[1].DOAnchorPosY(55, 0.5f);
    }
}
