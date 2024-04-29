using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerHPUI : MonoBehaviour
{
    public GameObject healthPrefab;

    private GameObject[] health;

    public void InitHP(int maxHp, int curHp)
    {
        health = new GameObject[maxHp];

        for (int i = 0; i < maxHp; i++)
        {
            GameObject h = Managers.Resource.Instantiate(healthPrefab, null);

            h.transform.parent = transform;

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
