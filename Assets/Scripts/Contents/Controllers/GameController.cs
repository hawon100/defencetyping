using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text[] text;
    public InputField typingInput;

    public BuildTower[] towers;
    public BuildTower tower;

    public GameObject towerSelectUI;
    public GameObject buildUI;

    public int gold;

    public float curDelayChange;
    public float maxDelayChange;

    private void Update()
    {
        Update_WordTyping();
        Update_Build();
    }

    private void Update_WordTyping()
    {
        for (int i = 0; i < text.Length; i++)
        {
            text[i].text = Managers.Typing._word[i];
        }

        Managers.Typing._input = typingInput.text;

        typingInput.text = Managers.Typing.WordEnter(typingInput.text);

        for (int i = 0; i < towers.Length; i++)
        {
            if (towers[i].isTyping)
            {
                tower = towers[i];
            }
        }
    }

    private void Update_Build()
    {
        if (Managers.Typing.tower == null) return;
        if (tower == null) return;

        Managers.Typing.tower.transform.parent = tower.transform;
        Managers.Typing.tower.transform.position = tower.transform.position;

        if (!tower.isTyping)
        {
            tower = null;
            Managers.Typing.tower = null;
        }
    }

    private void WordReload()
    {
        curDelayChange += Time.deltaTime;

        if (curDelayChange < maxDelayChange) return;

        Managers.Typing.WordReset();

        curDelayChange = 0;
    }

    public void BuildTowerSelect(string towerName)
    {
        if (tower == null) return;
        
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

        tower.type = Managers.Typing.type;

        towerSelectUI.SetActive(false);
        buildUI.SetActive(true);

        tower = null;
        Managers.Typing.tower = null;
    }
}