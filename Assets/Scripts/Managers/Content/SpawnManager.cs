using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [System.Serializable]
    public class SpawnMob
    {
        public GameObject Object;
        [Range(0, 100)] public int Probability;
    }

    public List<SpawnMob> spawnMob;
    public float spawnTime;
    public int spawnCount;

    private PoolManager poolManager; //이러한 것들을 실행시킬 것들이 필요

    private Vector3 spawnPos;

    private float timeRate;

    private void Awake()
    {
        poolManager = Managers.Pool;
    }

    private void Update()
    {
        if (timeRate >= spawnTime)
        {
            timeRate -= spawnTime;
            Spawn();
        }
        else
        {
            timeRate += Time.deltaTime;
        }   
    }

    public void Spawn()
    {
        for (int index = 0; index < spawnCount; index++)
        {
            for (int i = 0; i < spawnMob.Count; i++)
            {
                if (Random.Range(0, 100) < spawnMob[i].Probability)
                {
                    float deg = Random.Range(0, 360) * Mathf.Rad2Deg;

                    spawnPos.x = Mathf.Cos(deg) * 20f;
                    spawnPos.y = Mathf.Sin(deg) * 20f;

                    Poolable poolable = poolManager.Pop(spawnMob[i].Object, transform);

                    poolable.transform.parent = null;
                    poolable.transform.position = spawnPos;
                }
            }
        }
    }
}
