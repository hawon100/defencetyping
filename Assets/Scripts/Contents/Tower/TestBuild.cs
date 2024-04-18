using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBuild : MonoBehaviour
{
    public TowerBase towerBase;

    private void OnMouseDown()
    {
        Debug.Log("fewf!");
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Click!");
            GameObject tower = Managers.Resource.Instantiate(towerBase.gameObject, transform.parent = null);
            tower.transform.parent = transform;
            tower.transform.position = transform.position;
        }
    }
}
