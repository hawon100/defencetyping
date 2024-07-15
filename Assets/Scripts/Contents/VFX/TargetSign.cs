using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSign : MonoBehaviour
{
    public Transform target;
    public InstallTower tower;
    private void FixedUpdate()
    {
        if (!target || !tower) return;

        transform.position = target.position;

        if (target.gameObject.activeSelf && tower.gameObject.activeSelf) return;

        Managers.Resource.Destroy(this.gameObject);
    }
}
