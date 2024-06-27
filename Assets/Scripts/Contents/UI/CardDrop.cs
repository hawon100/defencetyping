using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardDrop : BaseDrop
{
    [HideInInspector] public string charName;
    public Image _image;

    private void Awake()
    {
        _rect = GetComponent<RectTransform>();
        _image = Util.FindChild<Image>(gameObject, "pairing");
        _image.enabled = false;
    }

    private void Update()
    {
        if (Util.FindChild<Drag>(gameObject) != null)
        {
            holderList.UpdateHolderList(charName, _image, false);
            holderList.ResetHolderList(charName);
        }
        else
        {
            holderList.UpdateHolderList(charName, _image, true);
        }
    }

    public override void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            if (eventData.pointerDrag.layer == LayerMask.NameToLayer("EditUI"))
            {
                if (charName == Util.FindChild<Text>(eventData.pointerDrag.gameObject, "ObjName").text)
                {
                    eventData.pointerDrag.transform.SetParent(transform);
                    eventData.pointerDrag.GetComponent<RectTransform>().position = _rect.position;
                }
                else
                {
                    return;
                }
            }
        }
    }
}