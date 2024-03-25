using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolArea : MonoBehaviour
{
    [System.Serializable]
    public class PoolObject
    {
        public GameObject pObject;
        public int maxAmount;
    }

    public List<PoolObject> poolObjects = new List<PoolObject>();

    private PoolManager poolManager;

    private void Awake()
    {
        poolManager = Managers.Pool;
        poolManager.Init();

        for (int i = 0; i < poolObjects.Count; i++)
        {
            poolManager.CreatePool(poolObjects[i].pObject, poolObjects[i].maxAmount);
        }
    }
}
