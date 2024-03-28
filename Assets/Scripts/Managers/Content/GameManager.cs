using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Player")]
    public Transform target; //따로 Script 제작
    //Managers.Game.target = target
    //모든 데이터는 Scene이 아닌 Script 내에 저장할 것!

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
