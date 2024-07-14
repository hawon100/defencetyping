using UnityEngine;
using DG.Tweening;

public class BuildTower : MonoBehaviour
{
    public RectTransform WordPanel;
    public RectTransform InputPanel;
    public bool isTyping = false;
    public GameController gameCtrl;
    public Define.InstallTowerType type;
    public int count;

    //Temp
    public Vector2 hpPos;

    private void Update()
    {
        OnKeyBoardEvent();

        if (!isTyping) return;

        GameObject towerBuild = Util.FindChild(gameObject);

        if (towerBuild != null)
        {
            gameCtrl.buildUI.SetActive(false);

            if (towerBuild.GetComponent<CenteralTowerStat>() == null) return;
            if(towerBuild.GetComponent<CenteralTowerStat>().enabled)
            {
                gameCtrl.captainUI.SetActive(true);
            }
            else
            {
                gameCtrl.towerUI.SetActive(true);
            }
        }
        else
        {
            gameCtrl.towerUI.SetActive(false);
            gameCtrl.captainUI.SetActive(false);
        }
    }

    private void OnKeyBoardEvent()
    {
        var key = (KeyCode)((int)KeyCode.F1 + count);

        if (Input.GetKeyDown(key))
        {
            ShortCutKey();
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            gameCtrl.curDelayChange = 0;
        }
    }

    private void ShortCutKey()
    {
        for (int i = 0; i < gameCtrl.towers.Count; i++)
        {
            gameCtrl.towers[i].isTyping = false;
        }

        gameCtrl.towerSelectUI.SetActive(true);
        gameCtrl.buildUI.SetActive(false);
        gameCtrl.captainUI.SetActive(false);
        gameCtrl.towerUI.SetActive(false);

        gameCtrl.curDelayChange = 0;
        Managers.Typing.tower = this.gameObject;
        Managers.Typing.curBuildPos = transform.position; //Temp
        PanelOpen();
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
        WordPanel.DOAnchorPosY(690, 0.5f);
        InputPanel.DOAnchorPosY(-690, 0.5f);
        gameCtrl.buildUI.SetActive(false);
        gameCtrl.towerUI.SetActive(false);
        gameCtrl.captainUI.SetActive(false);
        isTyping = false;
    }
}
