using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Drop : MonoBehaviour, IDropHandler
{
    private RectTransform _rect;

    private void Awake()
    {
        _rect = GetComponent<RectTransform>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            Debug.Log($"Detect Character Card - {Util.FindChild<Text>(eventData.pointerDrag.gameObject, "ObjName").text}");
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
