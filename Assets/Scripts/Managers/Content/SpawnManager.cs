using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [System.Serializable]
    public class SpawnMob
    {
        public Poolable poolable;
        public int maxAmount;
    }
    //Temp
    public List<SpawnMob> spawnEnemys = new List<SpawnMob>();
    public Transform[] spawnPoints;
    public float cooltime;

    private PoolManager poolManager;

    private float timeRate;

    [Header("Picking")]
    public Transform target;
    private void Awake()
    {
        poolManager = Managers.Pool;

        poolManager.Init();

        for (int i = 0; i < spawnEnemys.Count; i++)
        {
            spawnEnemys[i].poolable.gameObject.GetComponent<EnemyBase>().target = target;
            poolManager.CreatePool(spawnEnemys[i].poolable.gameObject, spawnEnemys[i].maxAmount);
        }
    }

    private void Update()
    {
        if (timeRate >= cooltime)
        {
            timeRate -= cooltime;
            Spawn();
        }
        else
        {
            timeRate += Time.deltaTime;
        }   
    }

    public void Spawn()
    {
        int e = Random.Range(0, spawnEnemys.Count);
        int s = Random.Range(0, spawnPoints.Length);

        Poolable poolable = poolManager.Pop(spawnEnemys[e].poolable.gameObject, spawnPoints[s]);

        poolable.transform.parent = null;
        poolable.transform.position = spawnPoints[s].position;
    }
}
