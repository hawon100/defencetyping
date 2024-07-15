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
        Managers.DSL.charData = JsonUtility.FromJson<Data.CharacterData>(jsonData);

        for (int i = 0; i < Managers.DSL.charData.characters.Count; i++) list.Add(Managers.Resource.Instantiate("UI/Lobby/CharCard"));
        foreach (var obj in list) Managers.Resource.Destroy(obj);

        for (int i = 0; i < Managers.DSL.charData.characters.Count; i++)
        {
            var obj = Managers.Resource.Instantiate("UI/Lobby/CharCard", spawnParent.transform);
            cards.Add(obj);

            Util.FindChild<Text>(obj, "ObjName").text = Managers.DSL.charData.characters[i].charName;
            Util.FindChild<Image>(obj, "Image").sprite = Resources.Load<Sprite>(Managers.DSL.charData.characters[i].pathImage);
            Util.FindChild<Text>(obj, "Level").text = $"Lv.{Managers.DSL.charData.characters[i].level}";

            int index = i;
            obj?.GetComponent<Button>().onClick.AddListener(() => LevelBtn(index, obj));
        }
    }

    private void Update()
    {
        for (int i = 0; i < Managers.DSL.charData.characters.Count; i++)
        {
            Util.FindChild<Text>(cards[i], "Level").text = $"Lv.{Managers.DSL.charData.characters[i].level}";
        }
    }

    public void LevelBtn(int index, GameObject obj)
    {
        levelPanel.DOAnchorPosY(-540, 0.5f);
        _objName = Util.FindChild<Text>(obj, "ObjName").text;

        if (!PlayerPrefs.HasKey("CharacterData")) return;

        Debug.Log(index);

        //Util.FindChild<Button>(levelPanel.gameObject, "Button")?.onClick.AddListener(() => LevelUp(index));

        //Debug.Log(PlayerPrefs.GetString("CharacterData"));

        Button levelUpButton = Util.FindChild<Button>(levelPanel.gameObject, "Button");
        levelUpButton.onClick.RemoveAllListeners(); // Remove all previous listeners
        levelUpButton.onClick.AddListener(() =>
        {
            LevelUp(index);
        });

        Debug.Log(PlayerPrefs.GetString("CharacterData"));
    }

    private void LevelUp(int index)
    {
        if (Managers.DSL.charData.characters[index].level == Managers.Data.LevelDict[Managers.Data.LevelDict.Count].level) return;

        string jsonData = PlayerPrefs.GetString("CharacterData");
        Managers.DSL.charData = JsonUtility.FromJson<Data.CharacterData>(jsonData);

        Managers.DSL.charData.characters[index].level++;

        string jsonSaveData = Managers.Data.SaveJson(Managers.DSL.charData);

        PlayerPrefs.SetString("CharacterData", jsonSaveData);
        PlayerPrefs.Save();
    }
}
