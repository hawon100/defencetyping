using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BackLevel : MonoBehaviour
{
    public GameObject spawnParent;
    public RectTransform levelPanel;
    public List<GameObject> list;
    public List<GameObject> cards;
    public string _objName;

    void Start()
    {
        if (!PlayerPrefs.HasKey("CharacterData")) return;

        string jsonData = PlayerPrefs.GetString("CharacterData");
        Managers.DSL.charData = JsonUtility.FromJson<Data.Save_CharacterData>(jsonData);

        for (int i = 0; i < Managers.DSL.charData.characters.Count; i++) list.Add(Managers.Resource.Instantiate("UI/Lobby/CharCard"));
        foreach (var obj in list) Managers.Resource.Destroy(obj);

        for (int i = 0; i < Managers.DSL.charData.characters.Count; i++)
        {
            var obj = Managers.Resource.Instantiate("UI/Lobby/CharCard", spawnParent.transform);
            cards.Add(obj);

            Util.FindChild<Text>(obj, "ObjName").text = Managers.DSL.charData.characters[i].charName;
            Util.FindChild<Image>(obj, "Image").sprite = Resources.Load<Sprite>(Managers.DSL.charData.characters[i].pathImage);
            Util.FindChild<Text>(obj, "Level").text = $"Lv.{Managers.DSL.charData.characters[i].level}";

            obj?.GetComponent<Button>().onClick.AddListener(() => LevelBtn(obj));
        }
    }

    private void Update()
    {
        for (int i = 0; i < Managers.DSL.charData.characters.Count; i++)
        {
            Util.FindChild<Text>(cards[i], "Level").text = $"Lv.{Managers.DSL.charData.characters[i].level}";
        }
    }

    public void LevelBtn(GameObject obj)
    {
        int index = 0;

        levelPanel.DOAnchorPosY(-540, 0.5f);
        _objName = Util.FindChild<Text>(obj, "ObjName").text;

        for(int i = 0; i < Managers.DSL.charData.characters.Count; i++)
        {
            if (Managers.DSL.charData.characters[i].charName == _objName)
            {
                index = i;
                break;
            }
        }

        if (!PlayerPrefs.HasKey("CharacterData")) return;

        Debug.Log(index);

        Util.FindChild<Button>(levelPanel.gameObject, "Button")?.onClick.AddListener(() => LevelUp(index));

        Debug.Log(PlayerPrefs.GetString("CharacterData"));
    }

    private void LevelUp(int index)
    {
        string jsonData = PlayerPrefs.GetString("CharacterData");
        Managers.DSL.charData = JsonUtility.FromJson<Data.Save_CharacterData>(jsonData);

        Managers.DSL.charData.characters[index].level++;

        string jsonSaveData = Managers.Data.SaveJson(Managers.DSL.charData);

        PlayerPrefs.SetString("CharacterData", jsonSaveData);
        PlayerPrefs.Save();
    }
}
