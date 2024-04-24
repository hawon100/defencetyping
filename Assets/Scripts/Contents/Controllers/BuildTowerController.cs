using UnityEngine;
using DG.Tweening;

public class BuildTowerController : MonoBehaviour
{
    int _mask;
    public RectTransform WordPanel;
    public RectTransform InputPanel;
    public bool isTyping = false;
    public Define.InstallTowerType type;

    public GameController gameCtrl;

    private void Start()
    {
        Managers.Input.MouseAction -= OnMouseEvent;
        Managers.Input.MouseAction += OnMouseEvent;

        _mask = (1 << (int)Define.Layer.Background) | (1 << (int)Define.Layer.TowerInstall) | (1 << (int)Define.Layer.Tower);
    }

    private void Update()
    {
        OnKeyBoardEvent();

        if (!isTyping) return;

        GameObject towerBuild = Util.FindChild(gameObject);

        if (towerBuild != null)
        {
            gameCtrl.buildUI.SetActive(false);
            gameCtrl.towerUI.SetActive(true);
        }
        else
        {
            gameCtrl.towerUI.SetActive(false);
        }
    }

    private void OnKeyBoardEvent()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            PanelClose();
        }
    }

    private void OnMouseEvent(Define.MouseEvent evt)
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 rayOrigin = new Vector2(mousePosition.x, mousePosition.y);
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.zero, 100.0f, _mask);
        Debug.DrawRay(rayOrigin, Vector2.zero * 100.0f, Color.red, 1.0f);

        if (hit.collider == null) return;

        if (hit.collider.gameObject.CompareTag("Background"))
        {
            OnMouseEvent_PanelClose(evt);
        }
    }

    private void OnMouseEvent_PanelClose(Define.MouseEvent evt)
    {
        if (evt == Define.MouseEvent.PointerDown)
        {
            gameCtrl.curDelayChange = 0;
            PanelClose();
        }
    }

    private void OnMouseDown()
    {
        for (int i = 0; i < gameCtrl.towers.Count; i++)
        {
            gameCtrl.towers[i].isTyping = false;
        }

        if (Input.GetMouseButtonDown(0))
        {
            GameController.Instance.curDelayChange = 0;
            
            PanelOpen();
        }
    }

    private void PanelOpen()
    {
        if (Util.FindChild(gameObject) == null)
        {
            gameCtrl.towerSelectUI.SetActive(true);
        }
        else
        {
            gameCtrl.towerSelectUI.SetActive(false);
        }

        Managers.Typing.WordReset();
        isTyping = true;
        WordPanel.DOAnchorPosY(540, 0.5f);
        InputPanel.DOAnchorPosY(-540, 0.5f);
    }

    private void PanelClose()
    {
        gameCtrl.buildUI.SetActive(false);
        gameCtrl.towerUI.SetActive(false);
        isTyping = false;
        WordPanel.DOAnchorPosY(690, 0.5f);
        InputPanel.DOAnchorPosY(-690, 0.5f);
    }
}
