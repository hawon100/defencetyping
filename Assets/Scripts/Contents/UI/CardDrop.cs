using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardDrop : BaseDrop
{
    public string charName;
    public Image _image;
    private string pathImage;

    protected override void Start()
    {
        base.Start();

        _image = Util.FindChild<Image>(gameObject, "pairing");
        _image.enabled = false;
        charName = Util.FindChild<Text>(gameObject, "Text").text;

        for(int i = 0; i < Managers.Data.CharacterDict.Count; i++)
        {
            if (Managers.Data.CharacterDict[i].charName == charName)
            {
                pathImage = Managers.Data.CharacterDict[i].pathImage;
            }
        }
    }

    private void Update()
    {
        if (Util.FindChild<Drag>(gameObject) != null)
        {
            holderList.UpdateHolderList(pathImage, charName, _image, false);
            holderList.ResetHolderList(charName);
        }
        else
        {
            holderList.UpdateHolderList(pathImage, charName, _image, true);
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