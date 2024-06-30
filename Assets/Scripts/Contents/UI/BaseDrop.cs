using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BaseDrop : MonoBehaviour, IDropHandler
{
    public RectTransform _rect;
    public HolderList holderList;

    protected virtual void Start()
    {
        holderList = FindObjectOfType<HolderList>();
        _rect = GetComponent<RectTransform>();
    }

    public virtual void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            if (Util.FindChild(gameObject) != null) return;

            if (eventData.pointerDrag.layer == LayerMask.NameToLayer("EditUI"))
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
