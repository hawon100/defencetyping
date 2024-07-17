using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardDrop : BaseDrop
{
    public string charName;
    public GameObject _image;
    public GameObject _text;
    public int _price;
    public float _time;
    private string pathImage;

    protected override void Start()
    {
        base.Start();

        _image = Util.FindChild(gameObject, "pairing");
        _text = Util.FindChild(_image, "Select");

        charName = Util.FindChild<Text>(gameObject, "Text").text;

        if(PlayerPrefs.HasKey("CharacterData"))
        {
            string jsonData = PlayerPrefs.GetString("CharacterData");
            Managers.DSL.charData = JsonUtility.FromJson<Data.CharacterData>(jsonData);

            for (int i = 0; i < Managers.DSL.charData.characters.Count; i++)
            {
                if (Managers.DSL.charData.characters[i].charName == charName)
                {
                    pathImage = Managers.DSL.charData.characters[i].pathImage;
                    _price = Managers.DSL.charData.characters[i].priceIn;
                    _time = Managers.DSL.charData.characters[i].time;
                }
            }
        }
    }

    private void Update()
    {
        if (Util.FindChild<Drag>(gameObject) != null)
        {
            holderList.UpdateHolderList(pathImage, charName, _price, _time, _text, false);
            holderList.ResetHolderList(charName);
        }
        else
        {
            holderList.UpdateHolderList(pathImage, charName, _price, _time, _text, true);
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