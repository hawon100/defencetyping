using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerInstaller : MonoBehaviour
{
    public TowerBase curTower;

    private Vector3 posVec;
    private void FixedUpdate()
    {
        ihavenoidea();
    }

    private void ihavenoidea()
    {
        posVec.x = Mathf.FloorToInt(Input.mousePosition.x);
        posVec.y = Mathf.FloorToInt(Input.mousePosition.y);

        transform.position = posVec;
    }
}
