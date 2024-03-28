using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Player")]
    public Transform target; //���� Script ����
    //Managers.Game.target = target
    //��� �����ʹ� Scene�� �ƴ� Script ���� ������ ��!

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
