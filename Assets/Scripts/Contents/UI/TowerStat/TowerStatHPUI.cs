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

    public void SetUI(Vector2 position, Canvas canvas)
    {
        Vector2 screenPoint = Camera.main.WorldToScreenPoint(position);
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, screenPoint, null, out Vector2 localPoint);
        uiRect.anchoredPosition = localPoint;
    }
}
