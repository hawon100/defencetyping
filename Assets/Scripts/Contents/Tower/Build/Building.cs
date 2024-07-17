using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public GameObject _build;

    private void Update()
    {
        if (Util.FindChild<TowerStat>(gameObject) != null)
        {
            _build.gameObject.SetActive(false);
        }
        else
        {
            _build.gameObject.SetActive(true);
        }
    }
}
