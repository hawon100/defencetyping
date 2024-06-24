using UnityEngine;
using UnityEngine.EventSystems;

public class StatInfomation : MonoBehaviour, IPointerEnterHandler
{
    public GameObject infomation;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Mouse Enter");
    }

    //private void Update()
    //{
    //    infomation.SetActive(IsPointerOverUI());
    //}
}