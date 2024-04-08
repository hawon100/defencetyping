using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolList : MonoBehaviour
{
    public Transform target; //test
    [System.Serializable]
    public class Poolist
    {
        public GameObject poolObject;
        public int maxAmount;
    }

    [Header("Pool List")]
    public List<Poolist> poolData;

    private PoolManager poolManager;

    private void Awake()
    {
        Managers.Game.target = target;
        Init();
    }

    private void Init()
    {
        poolManager = Managers.Pool;
        poolManager.Init();

        for (int i = 0; i < poolData.Count; i++)
        {
            poolManager.CreatePool(poolData[i].poolObject, poolData[i].maxAmount);
        }
    }
}
