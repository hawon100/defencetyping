using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerStatHPUI : MonoBehaviour
{
    public GameObject healthPrefab;
    public Transform hpSlot;
    public RectTransform hpPanel;

    private GameObject[] health;
    private Vector2 panelSize;

    private RectTransform uiRect;

    private void Awake()
    {
        uiRect = GetComponent<RectTransform>();
    }

    public void InitHP(int maxHp, int curHp)
    {
        health = new GameObject[maxHp];

        panelSize.x = 10 + 40 * maxHp;
        panelSize.y = 50;

        hpPanel.sizeDelta = panelSize;

        //Debug.Log("MAX HP : " + maxHp + ", HP : " + curHp);
        for (int i = 0; i < maxHp; i++)
        {
            GameObject h = Managers.Resource.Instantiate(healthPrefab, null);

            h.transform.parent = hpSlot;
            h.GetComponent<RectTransform>().localScale = Vector3.one;

            health[i] = h;
            health[i].SetActive(i < curHp);
        }
    }

    public void UpdateHP(int hp)
    {
        for (int i = 0; i < health.Length; i++)
        {
            health[i].SetActive(false);
        }

        for (int i = 0; i < hp; i++)
        {
            health[i].SetActive(true);
        }
    }

    //public void SetUI(Vector2 position, Canvas canvas)
    //{
    //    Vector2 screenPoint = Camera.main.WorldToScreenPoint(position);
    //    RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, screenPoint, null, out Vector2 localPoint);
    //    uiRect.anchoredPosition = localPoint;
    //}

    public Camera worldCamera; //Example

    public void SetUI(Vector2 position, Canvas canvas)
    {
        if (!Managers.Game.mainCamera) Managers.Game.mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();

        worldCamera = Managers.Game.mainCamera;

        // 1. World Space의 위치를 Screen Space로 변환
        //Vector3 screenPos = worldCamera.WorldToScreenPoint(position);

        // 2. Screen Space의 위치를 World Space Canvas의 RectTransform 좌표로 변환
        //RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, screenPos, worldCamera, out Vector2 localPoint);

        // 3. 변환된 좌표를 RectTransform의 로컬 포지션으로 설정
        //uiRect.localPosition = localPoint;

        //Debug.Log(worldCamera.WorldToScreenPoint(position));
        //uiRect.localPosition = worldCamera.WorldToScreenPoint(position);
        //uiRect.localPosition -= new Vector3(960f, 540f, 0f);

        Vector3 screenPos = worldCamera.WorldToScreenPoint(position);

        Vector2 uiPos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            uiRect.parent as RectTransform, screenPos, worldCamera, out uiPos);

        uiRect.localPosition = uiPos;
    }
}
