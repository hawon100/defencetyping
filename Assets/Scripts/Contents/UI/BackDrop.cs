using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BackDrop : BaseDrop
{
    public List<CardDrop> cardDrops;
    public List<GameObject> cards;

    public override void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            for(int i = 0; i < cardDrops.Count; i++)
            {
                if (eventData.pointerDrag.layer == LayerMask.NameToLayer("EditUI"))
                {
                    if (cardDrops[i].charName == Util.FindChild<Text>(eventData.pointerDrag.gameObject, "ObjName").text)
                    {
                        cards[i].transform.SetParent(cardDrops[i].transform);
                        cards[i].GetComponent<RectTransform>().position = cardDrops[i]._rect.position;
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