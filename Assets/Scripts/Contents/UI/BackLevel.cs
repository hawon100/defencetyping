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
            Util.FindChild<Text>(cards[i], "Level").text = $"Lv.{Managers.DSL.charData.characters[i].level} \n{Managers.DSL.charData.characters[i].priceOut}₩";
        }
    }

    public void LevelBtn(int index, GameObject obj)
    {
        levelPanel.DOAnchorPosY(-540, 0.5f);
        _objName = Util.FindChild<Text>(obj, "ObjName").text;

        if (!PlayerPrefs.HasKey("CharacterData")) return;

        Debug.Log(index);

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
        string jsonCharData = PlayerPrefs.GetString("CharacterData");
        Managers.DSL.charData = JsonUtility.FromJson<Data.CharacterData>(jsonCharData);
        string jsonGoldData = PlayerPrefs.GetString("GoldData");
        Managers.DSL.goldData = JsonUtility.FromJson<Data.GoldData>(jsonGoldData);

        if (Managers.DSL.charData.characters[index].level == Managers.Data.LevelDict[Managers.Data.LevelDict.Count].level) return;
        if (Managers.DSL.charData.characters[index].priceOut > Managers.DSL.goldData.coins[0].gold) return;

        Managers.DSL.goldData.coins[0].gold -= Managers.DSL.charData.characters[index].priceOut;
        Managers.DSL.charData.characters[index].priceOut *= 2;
        Managers.DSL.charData.characters[index].level++;

        string jsonCharSaveData = Managers.Data.SaveJson(Managers.DSL.charData);
        string jsonGoldSaveData = Managers.Data.SaveJson(Managers.DSL.goldData);

        PlayerPrefs.SetString("CharacterData", jsonCharSaveData);
        PlayerPrefs.Save();
        PlayerPrefs.SetString("GoldData", jsonGoldSaveData);
        PlayerPrefs.Save();
    }
}
