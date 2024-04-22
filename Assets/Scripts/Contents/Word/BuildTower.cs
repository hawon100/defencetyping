using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BuildTower : MonoBehaviour
{
    public GameObject bg;
    int _mask = (1 << (int)Define.Layer.Background) | (1 << (int)Define.Layer.TowerInstall) | (1 << (int)Define.Layer.Tower);
    public RectTransform WordPanel;
    public RectTransform InputPanel;
    public bool isTyping = false;
    public GameObject towerBuild;
    public GameObject towerSelectUI;
    public GameObject buildUI;
    public GameObject towerUI;
    public Define.InstallTowerType type;

    private void Start()
    {
        Managers.Input.MouseAction -= OnMouseEvent;
        Managers.Input.MouseAction += OnMouseEvent;
    }

    private void Update()
    {
        if (Managers.Typing.WordEnd(false))
        {
            PanelClose();
            isTyping = false;
        }

        towerBuild = Util.FindChild(gameObject);

        Debug.Log(towerBuild);

        if (!isTyping) return;

        if (towerBuild != null)
        {
            buildUI.SetActive(false);
            towerUI.SetActive(true);
        }
        else
        {
            towerUI.SetActive(false);
        }
    }

    private void OnMouseEvent(Define.MouseEvent evt)
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 rayOrigin = new Vector2(mousePosition.x, mousePosition.y);
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.zero, 100.0f, _mask);
        Debug.DrawRay(rayOrigin, Vector2.zero * 100.0f, Color.red, 1.0f);

        if (hit.collider == null) return;

        switch (hit.collider.gameObject.tag)
        {
            case "Background":
                OnMouseEvent_PanelClose(evt);
                break;
        }
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PanelOpen();
        }
    }

    private void OnMouseEvent_PanelClose(Define.MouseEvent evt)
    {
        switch (evt)
        {
            case Define.MouseEvent.PointerDown:
                PanelClose();
                break;
        }
    }

    private void PanelOpen()
    {
        if (towerBuild == null)
        {
            towerSelectUI.SetActive(true);
            buildUI.SetActive(false);
            towerUI.SetActive(false);
        }
        else
        {
            towerSelectUI.SetActive(false);
            buildUI.SetActive(false);
            towerUI.SetActive(false);
        }

        Managers.Typing.WordReset();
        isTyping = true;
        WordPanel.DOAnchorPosY(540, 0.5f);
        InputPanel.DOAnchorPosY(-540, 0.5f);
    }

    private void PanelClose()
    {
        isTyping = false;
        WordPanel.DOAnchorPosY(690, 0.5f);
        InputPanel.DOAnchorPosY(-690, 0.5f);
    }
}