using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardDrop : BaseDrop
{
    [HideInInspector] public string charName;
    private Image _image;

    private void Awake()
    {
        _rect = GetComponent<RectTransform>();
        _image = Util.FindChild<Image>(gameObject, "pairing");
        _image.enabled = false;
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
                    _image.enabled = true;
                }
                else
                {
                    _image.enabled = false;
                    return;
                }
            }
        }
    }
}