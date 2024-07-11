using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BackDrop : BaseDrop
{
    public GameObject spawnParent;
    public List<CardDrop> slots = new(); // slot object
    public List<GameObject> cards = new(); // card object
    public List<GameObject> shells = new(); // shells object
    public List<GameObject> _list = new(); // pool object
    public List<GameObject> parentSlot = new(); //select

    protected override void Start()
    {
        base.Start();

        if (!PlayerPrefs.HasKey("CharacterData")) return;
        string jsonData = PlayerPrefs.GetString("CharacterData");
        Managers.DSL.charData = JsonUtility.FromJson<Data.CharacterData>(jsonData);

        for (int i = 0; i < Managers.DSL.charData.characters.Count; i++) _list.Add(Managers.Resource.Instantiate("UI/Lobby/Slot"));
        foreach (var card in _list) Managers.Resource.Destroy(card);

        for (int i = 0; i < Managers.DSL.charData.characters.Count; i++)
        {
            var obj = Managers.Resource.Instantiate("UI/Lobby/Slot", spawnParent.transform);
            slots.Add(obj.GetComponent<CardDrop>());
            var cardObj = Util.FindChild(obj, "CharCard");
            cards.Add(cardObj);
            var shellObj = Util.FindChild(obj, "pairing");
            shells.Add(shellObj);

            Util.FindChild<Text>(obj, "Text").text = Managers.DSL.charData.characters[i].charName;

            Util.FindChild<Image>(cardObj, "Icon").sprite = Resources.Load<Sprite>($"{Managers.DSL.charData.characters[i].pathImage}");
            
            Util.FindChild<Text>(cardObj, "ObjName").text = Managers.DSL.charData.characters[i].charName;
            Util.FindChild<Text>(cardObj, "ObjNameEN").text = Managers.DSL.charData.characters[i].objName;

            Util.FindChild<Text>(cardObj, "Level").text = $"lv.{Managers.DSL.charData.characters[i].level}";

            Util.FindChild<Text>(shellObj, "ObjName").text = Managers.DSL.charData.characters[i].charName;
            Util.FindChild<Text>(shellObj, "ObjNameEN").text = Managers.DSL.charData.characters[i].objName;

            Util.FindChild<Text>(shellObj, "Level").text = $"lv.{Managers.DSL.charData.characters[i].level}";
        }

        if(PlayerPrefs.HasKey("TeamData"))
        {
            string jsonTeamData = PlayerPrefs.GetString("TeamData");
            Managers.DSL.teamData = JsonUtility.FromJson<Data.TeamEditData>(jsonTeamData);

            for (int j = 0; j < cards.Count; j++)
            {
                for (int i = 0; i < Managers.DSL.teamData.teams.Count; i++)
                {
                    if (Managers.DSL.teamData.teams[i].charName == Util.FindChild<Text>(cards[j], "ObjName").text)
                    {
                        cards[j].transform.SetParent(parentSlot[i].transform);
                        cards[j].transform.position = parentSlot[i].transform.position;
                    }
                }
            }
        }    
    }

    private void Update()
    {
        for(int i = 0; i < Managers.DSL.charData.characters.Count; i++)
        {
            Util.FindChild<Text>(cards[i], "Level").text = $"Lv.{Managers.DSL.charData.characters[i].level}";
            Util.FindChild<Text>(shells[i], "Level").text = $"lv.{Managers.DSL.charData.characters[i].level}";
        }
    }

    public override void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            for(int i = 0; i < slots.Count; i++)
            {
                if (eventData.pointerDrag.layer == LayerMask.NameToLayer("EditUI"))
                {
                    if (slots[i].charName == Util.FindChild<Text>(eventData.pointerDrag.gameObject, "ObjName").text)
                    {
                        cards[i].transform.SetParent(slots[i].transform);
                        cards[i].GetComponent<RectTransform>().position = slots[i]._rect.position;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }
    }
}