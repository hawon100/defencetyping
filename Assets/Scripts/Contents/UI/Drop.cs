using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Drop : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    private RectTransform _rect;

    private void Awake()
    {
        _rect = GetComponent<RectTransform>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //_image.color = Color.yellow;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //_image.color = Color.white;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            // Ư�� ���̾ �����Ͽ� ���ǿ� �´��� Ȯ��
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
