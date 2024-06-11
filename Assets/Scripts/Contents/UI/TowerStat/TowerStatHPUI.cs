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

    public void InitHP(int maxHp, int curHp)
    {
        health = new GameObject[maxHp];

        panelSize.x = 10 + 40 * maxHp;
        panelSize.y = 50;

        hpPanel.sizeDelta = panelSize;

        for (int i = 0; i < maxHp; i++)
        {
            GameObject h = Managers.Resource.Instantiate(healthPrefab, null);

            h.transform.parent = hpSlot;

            health[i] = h;
            health[i].SetActive(i <= curHp);
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
}
