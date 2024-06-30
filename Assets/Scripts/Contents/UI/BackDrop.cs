using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BackDrop : BaseDrop
{
    public GameObject spawnParent;
    public CharListData charListData;
    public List<CardDrop> slots = new(); // slot object
    public List<GameObject> cards = new(); // card object
    public List<GameObject> _list = new(); // pool object

    protected override void Start()
    {
        base.Start();

        for (int i = 0; i < Managers.Data.CharacterDict.Count; i++) _list.Add(Managers.Resource.Instantiate("UI/Lobby/Slot"));
        foreach(var card in _list) Managers.Resource.Destroy(card);

        for (int i = 0; i < Managers.Data.CharacterDict.Count; i++)
        {
            var obj = Managers.Resource.Instantiate("UI/Lobby/Slot", spawnParent.transform);
            slots.Add(obj.GetComponent<CardDrop>());
            var cardObj = Util.FindChild(obj, "CharCard");
            cards.Add(cardObj);

            Util.FindChild<Image>(cardObj, "Icon").sprite = charListData.dataEdit[i].charImage;
            Util.FindChild<Text>(cardObj, "ObjName").text = Managers.Data.CharacterDict[i].charName;
            Util.FindChild<Text>(cardObj, "Level").text = $"lv.{Managers.Data.CharacterDict[i].level}";
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