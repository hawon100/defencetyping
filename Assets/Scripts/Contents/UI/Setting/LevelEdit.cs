using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelEdit : MonoBehaviour
{
    public RectTransform levelEditWin;
    public GameObject content;
    public CharListData charList;
    List<GameObject> _objList = new();
    public List<GameObject> spawnList = new();

    private void Start()
    {
        for (int i = 0; i < charList.dataEdit.Count * 2; i++) _objList.Add(Managers.Resource.Instantiate("UI/Lobby/Character"));
        foreach (var obj in _objList) Managers.Resource.Destroy(obj);

        for (int i = 0; i < charList.dataEdit.Count; i++)
        {
            var obj = Managers.Resource.Instantiate("UI/Lobby/Character");
            spawnList.Add(obj);
            obj.transform.parent = content.transform;
            obj.name = charList.dataEdit[i].prefabName;
            Util.FindChild<Image>(obj, "Icon").sprite = charList.dataEdit[i].charImage;
            Util.FindChild<Text>(obj, "Name").text = charList.dataEdit[i].charName;
            Util.FindChild<Text>(obj, "Level").text = $"Lv.{charList.dataEdit[i].stat.level}";
            Util.FindChild<Text>(obj, "Price").text = $"{charList.dataEdit[i].stat.price}$";
            Util.FindChild<Button>(obj, "LevelUp").onClick.AddListener(() => LevelUpButton(obj));
        }
    }

    private void Update()
    {
        for (int i = 0; i < charList.dataEdit.Count; i++)
        {
            spawnList[i].transform.parent = content.transform;
            spawnList[i].name = charList.dataEdit[i].prefabName;
            Util.FindChild<Text>(spawnList[i], "Level").text = $"Lv.{charList.dataEdit[i].stat.level}";
            Util.FindChild<Text>(spawnList[i], "Price").text = $"{charList.dataEdit[i].stat.price}$";

            if (charList.dataEdit[i].stat.level >= UserStat.maxLevel)
            {
                Util.FindChild<Button>(spawnList[i], "LevelUp").gameObject.SetActive(false);
                Util.FindChild<Text>(spawnList[i], "Price").gameObject.SetActive(false);
                return;
            }
        }
    }

    private void LevelUpButton(GameObject obj)
    {
        Debug.Log($"Click Object : {Util.FindChild<Text>(obj, "Name").text}");
        for (int i = 0; i < charList.dataEdit.Count; i++)
        {
            if (Util.FindChild<Text>(obj, "Name").text == charList.dataEdit[i].charName)
            {
                if (charList.dataEdit[i].stat.level >= UserStat.maxLevel)
                {
                    Util.FindChild<Button>(spawnList[i], "LevelUp").gameObject.SetActive(false);
                    return;
                }

                if (UserStat.Gold < charList.dataEdit[i].stat.price) return;

                UserStat.Gold -= charList.dataEdit[i].stat.price;

                charList.dataEdit[i].stat.hp++;
                charList.dataEdit[i].stat.attack++;

                charList.dataEdit[i].stat.level++;
                charList.dataEdit[i].stat.price += 10;
            }
        }
    }

    public void OnExit()
    {
        levelEditWin.DOAnchorPosX(17.75f, 0.5f);
    }
}