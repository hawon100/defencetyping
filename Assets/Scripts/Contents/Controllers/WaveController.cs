using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Temp

public class WaveController : MonoBehaviour
{
    public Stage thisStage;

    [SerializeField] private Text waveText;
    [SerializeField] private Image analogPanel;
    [SerializeField] private GameObject returnButton;
    [SerializeField] private Color darkColor;
    [SerializeField] private Text gameText;

    [Header("GameController(Temp)")]
    public GameController gameController;
    [SerializeField] private BuildTower centeralTower;
    [SerializeField] private Transform installTowerGroup;
    private int curWave;

    List<GameObject> _towerList = new();
    List<GameObject> _functionList = new();

    private void Start()
    {
        Managers.Wave.WaveReset();

        thisStage = Managers.Game.currentStage;

        for (int i = 0; i < thisStage.TowerBuilderPos.Count; i++) _towerList.Add(Managers.Resource.Instantiate("Tower/Tower"));
        foreach(var obj in _towerList) Managers.Resource.Destroy(obj);
        for (int i = 0; i < thisStage.TowerBuilderPos.Count; i++) _functionList.Add(Managers.Resource.Instantiate($"ShortKey/F{i+2}"));
        foreach(var obj in _functionList) Managers.Resource.Destroy(obj);
        
        GameObject bg = Managers.Resource.Instantiate(thisStage.Background, null); 
        bg.transform.parent = installTowerGroup;

        TowerInit();

        Managers.Wave.spawnArea = new Transform[thisStage.Spawners.Count];
        Managers.Game.Init();

        for (int i = 0; i < thisStage.Spawners.Count; i++)
        {
            GameObject sa = Managers.Resource.Instantiate(thisStage.Spawners[i], transform.parent);

            Managers.Wave.spawnArea[i] = sa.transform;
        }

        Managers.Wave.stage = thisStage;
        Managers.Wave.WaveStart();
        UpdateWave_Temp();
    }

    private void TowerInit() //Temp
    {
        for (int i = 0; i < thisStage.TowerBuilderPos.Count; i++) 
        {
            //GameObject tb = Managers.Resource.Instantiate(thisStage.Tower[i].TowerBuilder.gameObject, null);
            var tb = Managers.Resource.Instantiate("Tower/Tower", installTowerGroup);
            var sk = Managers.Resource.Instantiate($"ShortKey/F{i + 2}", installTowerGroup);
            if (tb.GetComponent<BuildTower>().count == 0)
            {
                tb.GetComponent<BuildTower>().count = i + 1;
            }

            //tb.transform.parent = installTowerGroup;
            tb.transform.position = thisStage.TowerBuilderPos[i];
            //sk.transform.parent = installTowerGroup;
            sk.transform.position = thisStage.TowerBuilderPos[i] - new Vector2(0, 0.8f);
            BuildTower bt = tb.GetComponent<BuildTower>();
            bt.WordPanel = centeralTower.WordPanel;
            bt.InputPanel = centeralTower.InputPanel;
            bt.gameCtrl = centeralTower.gameCtrl;
            gameController.towers.Add(bt);
        }
    }

    private void FixedUpdate()
    {
        UpdateWave_Temp();
        UpdateGame(); //수정 사항!!
    }

    private void UpdateWave_Temp()
    {
        waveText.text = "Wave " + (Managers.Wave.currentWave + 1) + " (" + Managers.Wave.currentEnemy
            + "/" + Managers.Wave.currentAllEnemy + ")";
    }

    private void UpdateGame()
    {
        if (Managers.Wave.isWave) return;

        analogPanel.gameObject.SetActive(true);

        analogPanel.color = Color.Lerp(analogPanel.color, darkColor, 1.2f * Time.deltaTime);

        if (Mathf.Round(analogPanel.color.r) == darkColor.r)
        {
            returnButton.SetActive(true);
            gameController.typingInput.enabled = false;
            if (Managers.Wave.isWin)
            {
                gameText.text = "You Win !";
            }
            else
            {
                gameText.text = "Game Over !";
            }
        }
    }
}
